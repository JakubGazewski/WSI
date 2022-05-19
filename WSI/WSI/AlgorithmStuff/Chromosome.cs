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

        public StringBuilder sequence { get; }
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
        public void Correct()
        {
            if (!repeating) return;
            
            int emptyTileX = emptyTileStartX, emptyTileY = emptyTileStartY;
            for (int i = 0; i < sequence.Length; i++)
            {
                int tempEmptyTileX = emptyTileX, tempEmptyTileY = emptyTileY;

                switch (sequence[i])
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
                    Allel randomMove = (Allel)possibleMoves.GetValue(random.Next(possibleMoves.Length));
                    sequence[i] = (char)randomMove;

                    emptyTileX = tempEmptyTileX; emptyTileY = tempEmptyTileY;

                    switch (sequence[i])
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
        }

        public static int boardWidth { get; private set; } = 3;
        public static int boardHeight { get; private set; } = 3;
        public static int emptyTileStartX { get; private set; } = 0;
        public static int emptyTileStartY { get; private set; } = 0;
        public bool SetBoardProperties(int _boardWidth, int _boardHeight, int _emptyTileStartX, int _emptyTileStartY)
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
