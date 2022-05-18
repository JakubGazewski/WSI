using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSI.UI_stuff;

namespace WSI.AlgorithmStuff
{
    class Mutation
    {
        readonly Array moves = Enum.GetValues(typeof(Allel));
        readonly Random random = new();
        public readonly WrongMoveReaction wrongMoveReaction = WrongMoveReaction.repeatDraw;

        public void AddGene(ref StringBuilder chromosome, int boardWidth, int boardHeight, int emptyTileX, int emptyTileY, bool checking)
        {
            Allel randomMove = (Allel)moves.GetValue(random.Next(moves.Length));
            chromosome.Append((char)randomMove);

            while (!Check(chromosome, boardWidth, boardHeight, emptyTileX, emptyTileY) && checking)
            {
                randomMove = (Allel)moves.GetValue(random.Next(moves.Length));
                chromosome[chromosome.Length - 1] = (char)randomMove;
            }
        }

        public void MutateGene(ref StringBuilder chromosome, int index, int boardWidth, int boardHeight, int emptyTileX, int emptyTileY, bool checking)
        {
            //int randomIndex = random.Next(chromosome.Length);
            //Console.WriteLine(index);
            do
            {
                Allel randomMove = (Allel)moves.GetValue(random.Next(moves.Length));
                //Console.WriteLine(randomMove);
                chromosome[index] = (char)randomMove;
            } while (!Check(chromosome, boardWidth, boardHeight, emptyTileX, emptyTileY) && checking);
        }

        public bool Check(StringBuilder chromosome, int boardWidth, int boardHeight, int emptyTileX, int emptyTileY) //sprawdzenie czy nie ma ruchu poza planszę w wyniku mutacji
        {
            int width = emptyTileY, height = emptyTileX;

            //foreach (char c in chromosome)
            for(int i = 0; i < chromosome.Length; i++)
            {
                char c = chromosome[i];
                switch (c)
                {
                    case 'U':
                        height--;
                        break;
                    case 'D':
                        height++;
                        break;
                    case 'R':
                        width++;
                        break;
                    case 'L':
                        width--;
                        break;
                }
                //Console.WriteLine($"x:{width}, y:{height}");
                if (width < 0 || width >= boardWidth || height < 0 || height >= boardHeight)
                    return false;
            }
            return true;
        }

        //wartości mutate_chance i add_vs_mutate_chance od 0 do 100
        public void Mutate(ref StringBuilder chromosome, int mutate_chance, int add_vs_mutate_chance, int boardWidth, int boardHeight, int emptyTileX = 0, int emptyTileY = 0, bool allGenes = false) 
        {
            int index = allGenes ? 0 : random.Next(chromosome.Length);
            do
            {
                int mutationDraw = random.Next(100);
                //Console.WriteLine($"mutationDraw: {mutationDraw}");
                if (mutationDraw < mutate_chance)
                {
                    int addDraw = allGenes ? 101 : random.Next(100);
                    //Console.WriteLine($"addDraw: {addDraw}");
                    StringBuilder newChromosome = chromosome;

                    bool checking = wrongMoveReaction == WrongMoveReaction.repeatDraw;

                    if (addDraw < add_vs_mutate_chance)
                        AddGene(ref newChromosome, boardWidth, boardHeight, emptyTileX, emptyTileY, checking);
                    else
                        MutateGene(ref newChromosome, index, boardWidth, boardHeight, emptyTileX, emptyTileY, checking);
                }
            } while (++index < chromosome.Length && allGenes);
        }
    }
}
