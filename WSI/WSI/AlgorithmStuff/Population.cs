﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSI.AlgorithmStuff
{
    class Population
    {
        readonly Random random = new();
        public IList<Chromosome> Parents { get; set; }
        public IList<Chromosome> Children { get; set; }
        public int Count { get; set; }

        public delegate double Del(Chromosome chromosome);
        public Del FitnessFunction { get; set; }

        public IList<Chromosome> SelectByRoulette(bool bothPopulations)
        {
            List<Chromosome> pom = new(Parents.Concat(Children));
            if (!bothPopulations)
                pom = (List<Chromosome>)Children;

            double FitenssSum = 0;
            double[] roulettePercents = new double[pom.Count];
            
            for (int i = 0; i < pom.Count; i++)
            {
                FitenssSum += FitnessFunction(pom[i]);
            }
            
            roulettePercents[0] = (FitnessFunction(pom[0]) / FitenssSum) * 100;
            for (int i = 1; i < pom.Count; i++)
            {
                roulettePercents[i] = (FitnessFunction(pom[i]) / FitenssSum) * 100 + roulettePercents[i - 1];
            }

            List<Chromosome> newPopulation = new();

            for (int i = 0; i < Count; i++)
            {
                int makeDraw = random.Next(100);
                for (int j = 0; j < pom.Count; j++)
                {
                    if (roulettePercents[j] > makeDraw)
                    {
                        newPopulation.Add(pom[j]);
                        break;
                    }
                }
            }
            return newPopulation;
        }

        public IList<Chromosome> SelectBests() //wybieramy z największą wartością funkcji przyswtosowania
        {
            //int count = Parents.Count;
            List<Chromosome> p = (List<Chromosome>)Parents;
            p.AddRange(Children);
            p.Sort(CompareByFitnessFunction);
            return p.GetRange(0, Count);
        }

        public IList<Chromosome> SelectChildren()
        {
            List<Chromosome> pom = (List<Chromosome>)Children;
            return pom.GetRange(0,Count);
        }

        private int CompareByFitnessFunction(Chromosome chr1, Chromosome chr2)
        {
            if (FitnessFunction(chr1) > FitnessFunction(chr2))
                return -1;
            else if (FitnessFunction(chr1) < FitnessFunction(chr2))
                return 1;
            else
                return 0;
        }

    }
}
