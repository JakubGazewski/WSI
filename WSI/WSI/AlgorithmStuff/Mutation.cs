using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSI.UI_stuff;

namespace WSI.AlgorithmStuff
{
    public static class Mutation
    {
        private static readonly Array possibleMoves = Enum.GetValues(typeof(Allel));
        private static readonly Random random = new();

        //wartości mutateChance i addVsMutateChance od 0 do 100
        public static int MutateChance { set; get; } = 50;
        public static int AddVsMutateChance { set; get; } = 20;
        public static int AllVsOneChance { set; get; } = 20;
        public static bool AllGenes { set; get; } = false;

        public static void AddGene(Chromosome chromosome)
        {
            Allel randomMove = (Allel)possibleMoves.GetValue(random.Next(possibleMoves.Length));
            chromosome += randomMove;

            chromosome.Correct();

        }

        public static void MutateGene(Chromosome chromosome, int locus)
        {

            Allel randomMove = (Allel)possibleMoves.GetValue(random.Next(possibleMoves.Length));
            chromosome[locus] = (char)randomMove;

            chromosome.Correct();

        }

        public static void TryMutateAllGenes(Chromosome chromosome)
        {
            for(int i=0;i<chromosome.Length;i++)
            {
                int mutationDraw = random.Next(100);
                if (mutationDraw < MutateChance)
                    MutateGene(chromosome, i);
            }
        }

        public static void Mutate(Chromosome chromosome) 
        {
            int locus = AllGenes ? 0 : random.Next(chromosome.Length);
            do
            {
                int mutationDraw = random.Next(100);
                if (mutationDraw < MutateChance)
                {
                    int addDraw = AllGenes ? 101 : random.Next(100);

                    if (addDraw < AddVsMutateChance)
                        AddGene(chromosome);
                    else
                        MutateGene(chromosome, locus);
                }
            } while (++locus < chromosome.Length && AllGenes);
        }

        public static void MutateV2(Chromosome chromosome)
        {

            int mutationDraw = random.Next(100);
            int allVsOnedraw = random.Next(100);
            int addDraw = random.Next(100);
            if(mutationDraw<MutateChance)
            {
                if(allVsOnedraw < AllVsOneChance)
                {
                    if (addDraw < AddVsMutateChance)
                        AddGene(chromosome);
                    else
                        TryMutateAllGenes(chromosome);
                }
                else
                {
                    if (addDraw < AddVsMutateChance)
                        AddGene(chromosome);
                    else
                        MutateGene(chromosome, random.Next(chromosome.Length));
                }
            }
        }
    }
}
