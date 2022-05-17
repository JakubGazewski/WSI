using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSI.UI_stuff;

namespace WSI.AlgorithmStuff
{
    public enum Allel
    {
        U = 'U',
        D = 'D',
        R = 'R',
        L = 'L'
    }

    class Mutation
    {
        readonly Array moves = Enum.GetValues(typeof(Allel));
        readonly Random random = new();

        public void AddGene(ref string chromosome)
        {
            Allel randomMove = (Allel)moves.GetValue(random.Next(moves.Length));
            chromosome += (char)randomMove;
        }

        public void MutateGene(ref string chromosome)
        {
            int randomIndex = random.Next(chromosome.Length);
            //Console.WriteLine(randomIndex);
            Allel randomMove = (Allel)moves.GetValue(random.Next(moves.Length));
            //Console.WriteLine(randomMove);
            StringBuilder sb = new(chromosome);
            sb[randomIndex] = (char)randomMove;
            chromosome = sb.ToString();
        }

        public bool Check(string chromosome, int boardWidth, int boardHeight, int emptyTileX, int emptyTileY) //sprawdzenie czy nie ma ruchu poza planszę w wyniku mutacji
        {
            int width = emptyTileY, height = emptyTileX;

            foreach (char c in chromosome)
            {
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

        public void Mutate(ref string chromosome, int mutate_chance, int add_vs_mutate_chance, int boardWidth, int boardHeight, int emptyTileX = 0, int emptyTileY = 0) //wartości mutate_chance i add_vs_mutate_chance od 0 do 100
        {
            int chance = random.Next(100);
            //Console.WriteLine(chance);
            if (chance < mutate_chance)
            {
                int chance2 = random.Next(100);
                //Console.WriteLine(chance2);
                string newChromosome = chromosome;

                if (chance2 < add_vs_mutate_chance)
                    AddGene(ref newChromosome);
                else
                    MutateGene(ref newChromosome);
                //Console.WriteLine($"newChromosome:{newChromosome}");
                if (Check(newChromosome, boardWidth, boardHeight, emptyTileX, emptyTileY))
                {
                    chromosome = newChromosome;
                    //Console.WriteLine($"chromosome:{chromosome}");
                }
            }
        }
    }
}
