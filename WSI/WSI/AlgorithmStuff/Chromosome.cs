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
        
        public StringBuilder sequence { get; }
        public char this[int ind]
        {
            get => sequence[ind];
            set => sequence[ind] = value;
        }
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
