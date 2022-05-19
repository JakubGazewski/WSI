using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSI.AlgorithmStuff
{
    public static class Init
    {
        public static IList<Chromosome> GetStartngChromosomes(int chromosomesNumber, int chromosomesLength)
        {
            IList <Chromosome> chromosomes = new List<Chromosome>();

            for (int i = 0; i < chromosomesNumber; i++)
            {
                Chromosome chromosome = new Chromosome();
                for(int j = 0; j < chromosomesLength; j++)
                {
                    Mutation.AddGene(chromosome);
                }
                chromosomes.Add(chromosome);
            }

            return chromosomes;
        }
    }
}
