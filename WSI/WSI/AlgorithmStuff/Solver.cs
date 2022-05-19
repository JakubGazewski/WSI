using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSI.UI_stuff;

namespace WSI.AlgorithmStuff
{
    public class Solver
    {
        public readonly CrossOverType crossOverType = CrossOverType.SinglePoint;
        private int[,] startingBoard;
        private int size;
        private readonly double lenghtMultiplier = 0.01D;
        private readonly int populationSize = 8;
        private readonly int chromosomeLength = 10;
        private readonly double acceptanceValue = 0D;

        public Solver(Board board)
        {
            size = board.size;
            startingBoard = new int[size, size];

            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    startingBoard[i, j] = board.tiles[i, j].OriginalHeightPosition*board.size + board.tiles[i, j].OriginalWidthPosition;
                }
            }

            Chromosome.SetBoardProperties(size, size, size - 1, size - 1);
        }

        public (StringBuilder, int, StringBuilder, int) SolvePuzzle(int maxIterations, AlgorithmChoice choice) // returns solution and number of iterations (optionaly solution and number of iterations for second algorith, default evolutionary)
        {
            switch(choice)
            {
                case AlgorithmChoice.Genetic:
                    break;
                case AlgorithmChoice.Evolution:
                    break;
                case AlgorithmChoice.Both:
                    break;
            }

            return (null, 0, null, 0);
        }

        public async Task<(StringBuilder, int)> GeneticAlgorithm(int maxIterations)
        {
            Population population = new Population();
            population.FitnessFunction = FitnessFunctionManhattanDistance;
            population.Children = new List<Chromosome>();
            population.Parents = Init.GetStartngChromosomes(populationSize, chromosomeLength);

            int iterationCount = 1;
            while (iterationCount <= maxIterations)
            {
                StringBuilder isFinished = IsFinished(population.Parents);
                if (isFinished != null)
                    return (isFinished, iterationCount);

                // cross over




                iterationCount++;
            }

            return (null, iterationCount);
        }

        public async Task<(StringBuilder, int)> EvolutionaryAlgorithm(int maxIterations)
        {
            Population population = new Population();
            population.FitnessFunction = FitnessFunctionManhattanDistance;
            population.Children = new List<Chromosome>();
            population.Parents = Init.GetStartngChromosomes(populationSize, chromosomeLength);

            int iterationCount = 1;
            while (iterationCount <= maxIterations)
            {
                StringBuilder isFinished = IsFinished(population.Parents);
                if (isFinished != null)
                    return (isFinished, iterationCount);


                iterationCount++;
            }

            return (null, iterationCount);
        }

        private StringBuilder IsFinished(List<Chromosome> chromosomes)
        {
            foreach(Chromosome chromosome in chromosomes)
            {
                if(FitnessFunctionManhattanDistance(chromosome) <= acceptanceValue)
                {
                    StringBuilder result = new StringBuilder();
                    // corrected chromosome and return result
                }
            }

            return null;
        }

        private double FitnessFunctionManhattanDistance(Chromosome chromosome)
        {
            double distance = 0;
            int [,] board = ApplyMoves(chromosome);
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    distance += Math.Abs(board[i,j]/size - i) + Math.Abs(board[i,j]%size - j);
                }
            }
            distance /= size * size;
            distance += chromosome.Length * lenghtMultiplier;
            return distance;
        }

        private double FitnessFunctionEuclideanDistance(Chromosome chromosome)
        {
            double distance = 0;
            int[,] board = ApplyMoves(chromosome);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    distance += Math.Pow(board[i, j] / size - i, 2) + Math.Pow(board[i, j] % size - j, 2);
                }
            }
            distance /= size * size;
            distance += chromosome.Length * lenghtMultiplier;
            return distance;
        }

        private int[,] ApplyMoves(Chromosome chromosome)
        {
            int[,] board = startingBoard.Clone() as int[,];
            int blankX = size - 1;
            int blankY = size - 1;
            int blank = size * size - 1;

            foreach (Allel move in chromosome.sequence.ToString())
            {
                switch (move)
                {
                    case Allel.D:
                        board[blankX, blankY] = board[blankX, blankY + 1];
                        board[blankX, blankY + 1] = blank;
                        blankY++;
                        break;
                    case Allel.U:
                        board[blankX, blankY] = board[blankX, blankY - 1];
                        board[blankX, blankY - 1] = blank;
                        blankY--;
                        break;
                    case Allel.R:
                        board[blankX, blankY] = board[blankX + 1, blankY];
                        board[blankX + 1, blankY] = blank;
                        blankX++;
                        break;
                    case Allel.L:
                        board[blankX, blankY] = board[blankX - 1, blankY];
                        board[blankX - 1, blankY] = blank;
                        blankX--;
                        break;
                }
            }
            return board;
        }

    }
}
