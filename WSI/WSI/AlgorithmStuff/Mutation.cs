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
        public static int mutateChance { set; get; } = 50;
        public static int addVsMutateChance { set; get; } = 20;
        public static bool allGenes { set; get; } = false;

        public static void AddGene(Chromosome chromosome)
        {
            Allel randomMove = (Allel)possibleMoves.GetValue(random.Next(possibleMoves.Length));
            chromosome.sequence.Append((char)randomMove);

            while (!chromosome.CheckCorectness() && Chromosome.repeating)
            {
                randomMove = (Allel)possibleMoves.GetValue(random.Next(possibleMoves.Length));
                chromosome[chromosome.Length - 1] = (char)randomMove;
            }
        }

        public static void MutateGene(Chromosome chromosome, int index)
        {
            do
            {
                Allel randomMove = (Allel)possibleMoves.GetValue(random.Next(possibleMoves.Length));
                chromosome[index] = (char)randomMove;
            } while (!chromosome.CheckCorectness() && Chromosome.repeating);
        }

        public static void Mutate(Chromosome chromosome) 
        {
            int index = allGenes ? 0 : random.Next(chromosome.Length);
            do
            {
                int mutationDraw = random.Next(100);
                if (mutationDraw < mutateChance)
                {
                    int addDraw = allGenes ? 101 : random.Next(100);

                    if (addDraw < addVsMutateChance)
                        AddGene(chromosome);
                    else
                        MutateGene(chromosome, index);
                }
            } while (++index < chromosome.Length && allGenes);
        }
    }
}
