﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSI.AlgorithmStuff
{
    public static class Init
    {
        public static List<Chromosome> GetStartngChromosomes(int chromosomesNumber, int chromosomesLength)
        {
            List <Chromosome> chromosomes = new List<Chromosome>();

            for (int i = 0; i < chromosomesNumber; i++)
            {
                Chromosome chromosome = new Chromosome();
                for(int j = 0; j < chromosomesLength; j++)
                {
                    Mutation.AddGene(chromosome);
                }
                chromosome.sequence = chromosome.Correct();
                chromosomes.Add(chromosome);
            }

            return chromosomes;
        }
    }
}
