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
        public readonly WrongMoveReaction wrongMoveReaction = WrongMoveReaction.ignore;

        public void AddGene(ref StringBuilder chromosome)
        {
            Allel randomMove = (Allel)moves.GetValue(random.Next(moves.Length));
            chromosome.Append((char)randomMove);
        }

        public void MutateGene(ref StringBuilder chromosome)
        {
            int randomIndex = random.Next(chromosome.Length);
            //Console.WriteLine(randomIndex);
            Allel randomMove = (Allel)moves.GetValue(random.Next(moves.Length));
            //Console.WriteLine(randomMove);
            chromosome[randomIndex] = (char)randomMove;
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
        public void Mutate(ref StringBuilder chromosome, int mutate_chance, int add_vs_mutate_chance, int boardWidth, int boardHeight, int emptyTileX = 0, int emptyTileY = 0) 
        {
            int mutationDraw = random.Next(100);
            //Console.WriteLine(chance);
            if (mutationDraw < mutate_chance)
            {
                int addDraw = random.Next(100);
                //Console.WriteLine(chance2);
                StringBuilder newChromosome = chromosome;

                bool canGoOn = wrongMoveReaction == WrongMoveReaction.ignore ? true : false;
                do
                {
                    if (addDraw < add_vs_mutate_chance)
                        AddGene(ref newChromosome);
                    else
                        MutateGene(ref newChromosome);
                    if(Check(newChromosome, boardWidth, boardHeight, emptyTileX, emptyTileY)) canGoOn = true;
                } while (!canGoOn);

            }
        }
    }
}
