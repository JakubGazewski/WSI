using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSI.AlgorithmStuff
{
    public class Chromosome
    {
        private static readonly WrongMoveReaction wrongMoveReaction = WrongMoveReaction.repeatDraw;
        public static bool repeating { get => wrongMoveReaction == WrongMoveReaction.repeatDraw; }
        private static readonly Array possibleMoves = Enum.GetValues(typeof(Allel));
        private static readonly Random random = new();
        
        public StringBuilder sequence { get; set; }
        public char this[int ind]
        {
            get => sequence[ind];
            set => sequence[ind] = value;
        }
        public static Chromosome operator + (Chromosome chromosome, Allel allel)
        { chromosome.sequence.Append((char)allel); return chromosome; }

        public int Length
        {
            get => sequence.Length;
        }

        public Chromosome()
        {
            sequence = new StringBuilder();
        }

        // sprawdzenie czy nie ma ruchu poza planszę
        public bool CheckCorectness()
        {
            int exptyTileX = emptyTileStartX, emptyTileY = emptyTileStartY;

            for (int i = 0; i < sequence.Length; i++)
            {
                char c = sequence[i];
                switch (c)
                {
                    case 'U':
                        emptyTileY--;
                        break;
                    case 'D':
                        emptyTileY++;
                        break;
                    case 'R':
                        exptyTileX++;
                        break;
                    case 'L':
                        exptyTileX--;
                        break;
                }
                if (exptyTileX < 0 || exptyTileX >= boardWidth || emptyTileY < 0 || emptyTileY >= boardHeight)
                    return false;
            }
            return true;
        }

        // przechodzi jeden raz po całym chromosomie, losując jeszcze raz allel tam, gdzie biale pole wychodzi poza planszę
        public StringBuilder Correct()
        {
            if (!repeating) return new StringBuilder(sequence.ToString());

            StringBuilder correctedSequence = new(sequence.ToString());
            int emptyTileX = emptyTileStartX, emptyTileY = emptyTileStartY;
            for (int i = 0; i < sequence.Length; i++)
            {
                int tempEmptyTileX = emptyTileX, tempEmptyTileY = emptyTileY;

                switch (correctedSequence[i])
                {
                    case 'U':
                        emptyTileY--;
                        break;
                    case 'D':
                        emptyTileY++;
                        break;
                    case 'R':
                        emptyTileX++;
                        break;
                    case 'L':
                        emptyTileX--;
                        break;
                }

                while (emptyTileX < 0 || emptyTileX >= boardWidth || emptyTileY < 0 || emptyTileY >= boardHeight)
                {
                    List<Allel> correctPossibleMoves = possibleMoves.OfType<Allel>().ToList();
                    //if (i > 0) //jest poprzednik
                    //{
                    if ((emptyTileX - 1 < 0 && emptyTileY < 0) || (emptyTileX < 0 && emptyTileY - 1 < 0)) //lewy górny róg
                    {
                        if (i > 0)
                            correctedSequence[i] = correctedSequence[i - 1] == 'L' ? 'D' : 'R';
                        else
                        {
                            correctPossibleMoves.Remove(Allel.L);
                            correctPossibleMoves.Remove(Allel.U);
                            int index = random.Next(2);
                            correctedSequence[i] = (char)correctPossibleMoves[index];
                        }
                    }
                    else if (emptyTileX + 1 >= boardWidth && emptyTileY < 0 || emptyTileX >= boardWidth && emptyTileY - 1 < 0) //prawy górny róg
                    {
                        if (i > 0)
                            correctedSequence[i] = correctedSequence[i - 1] == 'R' ? 'D' : 'L';
                        else
                        {
                            correctPossibleMoves.Remove(Allel.R);
                            correctPossibleMoves.Remove(Allel.U);
                            int index = random.Next(2);
                            correctedSequence[i] = (char)correctPossibleMoves[index];
                        }
                    }
                    else if (emptyTileX - 1 < 0 && emptyTileY >= boardHeight || emptyTileX < 0 && emptyTileY + 1 >= boardHeight) //lewy dolny róg
                    {
                        if (i > 0)
                            correctedSequence[i] = correctedSequence[i - 1] == 'L' ? 'U' : 'R';
                        else
                        {
                            correctPossibleMoves.Remove(Allel.L);
                            correctPossibleMoves.Remove(Allel.D);
                            int index = random.Next(2);
                            correctedSequence[i] = (char)correctPossibleMoves[index];
                        }
                    }
                    else if (emptyTileX + 1 >= boardWidth && emptyTileY >= boardHeight || emptyTileX >= boardWidth && emptyTileY + 1 >= boardHeight) //prawy dolny róg
                    {
                        if (i > 0)
                            correctedSequence[i] = correctedSequence[i - 1] == 'R' ? 'U' : 'L';
                        else
                        {
                            correctPossibleMoves.Remove(Allel.R);
                            correctPossibleMoves.Remove(Allel.D);
                            int index = random.Next(2);
                            correctedSequence[i] = (char)correctPossibleMoves[index];
                        }
                    }
                    else if (emptyTileX < 0) //lewa krawędź
                    {
                        if (i > 0)
                        {
                            Allel prevGene = sequence[i - 1] == 'L' ? Allel.R : sequence[i - 1] == 'U' ? Allel.D : Allel.U;
                            correctPossibleMoves.Remove(prevGene);
                        }
                            correctPossibleMoves.Remove(Allel.L);
                            int index = random.Next(correctPossibleMoves.Count);
                            correctedSequence[i] = (char)correctPossibleMoves[index];
                    }
                    else if (emptyTileX >= boardWidth) //prawa krawędź
                    {
                        if (i > 0)
                        {
                            Allel prevGene = sequence[i - 1] == 'R' ? Allel.L : sequence[i - 1] == 'U' ? Allel.D : Allel.U;
                            correctPossibleMoves.Remove(prevGene);
                        }
                            correctPossibleMoves.Remove(Allel.R);
                            int index = random.Next(correctPossibleMoves.Count);
                            correctedSequence[i] = (char)correctPossibleMoves[index];
                    }
                    else if (emptyTileY < 0) //górna krawędź
                    {
                        if (i > 0)
                        {
                            Allel prevGene = sequence[i - 1] == 'U' ? Allel.D : sequence[i - 1] == 'R' ? Allel.L : Allel.R;
                            correctPossibleMoves.Remove(prevGene);
                        }
                            correctPossibleMoves.Remove(Allel.U);
                            int index = random.Next(correctPossibleMoves.Count);
                            correctedSequence[i] = (char)correctPossibleMoves[index];
                    }
                    else if (emptyTileY >= boardHeight) //dolna krawędź
                    {
                        if (i > 0)
                        {
                            Allel prevGene = sequence[i - 1] == 'D' ? Allel.U : sequence[i - 1] == 'R' ? Allel.L : Allel.R;
                            correctPossibleMoves.Remove(prevGene);
                        }
                            correctPossibleMoves.Remove(Allel.D);
                            int index = random.Next(correctPossibleMoves.Count);
                            correctedSequence[i] = (char)correctPossibleMoves[index];
                    }
                    //}
                    /*
                    else //nie ma poprzednika
                    {
                        correctPossibleMoves.Remove((Allel)sequence[i]);
                        int index = random.Next(3);
                        correctedSequence[i] = (char)correctPossibleMoves[index];
                    }
                    */
                    emptyTileX = tempEmptyTileX; emptyTileY = tempEmptyTileY;

                    switch (correctedSequence[i])
                    {
                        case 'U':
                            emptyTileY--;
                            break;
                        case 'D':
                            emptyTileY++;
                            break;
                        case 'R':
                            emptyTileX++;
                            break;
                        case 'L':
                            emptyTileX--;
                            break;
                    }
                }
            }
            return correctedSequence;
        }

        public static int boardWidth { get; private set; } = 3;
        public static int boardHeight { get; private set; } = 3;
        public static int emptyTileStartX { get; private set; } = 0;
        public static int emptyTileStartY { get; private set; } = 0;
        public static bool SetBoardProperties(int _boardWidth, int _boardHeight, int _emptyTileStartX, int _emptyTileStartY)
        {
            if (_boardWidth != _boardHeight) return false;
            if (_emptyTileStartX < 0 || _emptyTileStartX >= _boardWidth || _emptyTileStartY < 0 || _emptyTileStartY >= _boardHeight) return false;

            boardWidth = _boardWidth;
            boardHeight = _boardHeight;
            emptyTileStartX = _emptyTileStartX;
            emptyTileStartY = _emptyTileStartY;

            return true;
        }
    }
}
