using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSI.AlgorithmStuff
{
    class Init
    {
        private int _boardWidth; 
        private int _boardHeight; 
        private int _emptyTileX; 
        private int _emptyTileY;


        public Init(int boardWidth, int boardHeight, int emptyTileX = 0, int emptyTileY = 0)
        {
            _boardWidth = boardWidth;
            _boardHeight = boardHeight;
            _emptyTileX = emptyTileX;
            _emptyTileY = emptyTileY;
        }


        public IList<StringBuilder> GetStartngChromosomes(int chromosomesNumber, int chromosomesLength)
        {
            IList <StringBuilder> chromosomes = new List<StringBuilder>();
            Mutation mutation = new Mutation();

            for (int i = 0; i < chromosomesNumber; i++)
            {
                StringBuilder chromosome = new StringBuilder();
                for(int j = 0; j < chromosomesLength; j++)
                {
                    bool canGoOn = mutation.wrongMoveReaction == WrongMoveReaction.ignore ? true : false;
                    do
                    {
                        mutation.AddGene(ref chromosome);
                        if (mutation.Check(chromosome, _boardWidth, _boardHeight, _emptyTileX, _emptyTileY)) canGoOn = true;
                    } while (!canGoOn);
                }
                chromosomes.Add(chromosome);
            }

            return chromosomes;
        }
    }
}
