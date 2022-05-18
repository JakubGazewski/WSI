using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSI.AlgorithmStuff
{
    class Population
    {
        readonly Random random = new Random();
        public IList<StringBuilder> Parents { get; set; }
        public IList<StringBuilder> Children { get; set; }

        public delegate double Del(StringBuilder chromosome);
        public Del FitnessFunction { get; set; }

        public void SelectByRoulette(bool bothPopulations)
        {
            List<StringBuilder> pom = new List<StringBuilder>(Parents.Concat(Children));
            if (!bothPopulations)
                pom = (List<StringBuilder>)Children;
            //Console.WriteLine(pom.Count);

            double FitenssSum = 0;
            double[] roulettePercents = new double[pom.Count];
            //Console.WriteLine(roulettePercents.Length);
            for (int i = 0; i < pom.Count; i++)
            {
                FitenssSum += FitnessFunction(pom[i]);
            }
            //Console.WriteLine(FitenssSum);
            roulettePercents[0] = (FitnessFunction(pom[0]) / FitenssSum) * 100;
            //Console.WriteLine(roulettePercents[0]);
            for (int i = 1; i < pom.Count; i++)
            {
                roulettePercents[i] = (FitnessFunction(pom[i]) / FitenssSum) * 100 + roulettePercents[i - 1];
                //Console.WriteLine(roulettePercents[i]);
            }

            List<StringBuilder> newPopulation = new List<StringBuilder>();

            for (int i = 0; i < Parents.Count; i++)
            {
                int makeDraw = random.Next(100);
                //Console.WriteLine(makeDraw);
                for (int j = 0; j < pom.Count; j++)
                {
                    if (roulettePercents[j] > makeDraw)
                    {
                        //Console.WriteLine(roulettePercents[j]);
                        newPopulation.Add(pom[j]);
                        break;
                    }
                }
            }
            //Console.WriteLine(newPopulation.Count);
            Parents = newPopulation;
        }

        public void SelectBests() //wybieramy z największą wartością funkcji przyswtosowania
        {
            int count = Parents.Count;
            List<StringBuilder> p = (List<StringBuilder>)Parents;
            p.AddRange(Children);
            p.Sort(CompareByFitnessFunction);
            Parents = p.GetRange(0, count);
        }
        public void SelectChildren()
        {
            Parents = Children;
        }

        private int CompareByFitnessFunction(StringBuilder sb1, StringBuilder sb2)
        {
            if (FitnessFunction(sb1) > FitnessFunction(sb2))
                return -1;
            else if (FitnessFunction(sb1) < FitnessFunction(sb2))
                return 1;
            else
                return 0;
        }

    }
}
