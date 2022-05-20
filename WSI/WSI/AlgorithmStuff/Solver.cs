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
        public readonly ChromosomesSelection chromosomesSelection = ChromosomesSelection.ElitarismAndBestCrossOver;
        private int[,] startingBoard;
        private int size;
        private readonly double lenghtMultiplier = 0.01D;
        private readonly int populationSize = 40;
        private readonly int chromosomeLength = 10;
        private readonly double acceptanceValue = 0D;
        private readonly double elitarismPercent = 0.1D;
        private static readonly Random random = new();
        private readonly int nPointCrossOver = 5;
        private readonly double mutationChance = 0.2;

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
            IList<Chromosome> newPopulation = new List<Chromosome>();
            IList<Chromosome> crossOverPopulation = new List<Chromosome>();
            int eliteSize = (int)(elitarismPercent * populationSize / 100D);

            int iterationCount = 1;
            while (iterationCount <= maxIterations)
            {
                StringBuilder isFinished = IsFinished(population.Parents);
                if (isFinished != null)
                    return (isFinished, iterationCount);

                population.Parents = population.Sort(population.Parents);


                // cross over
                switch (chromosomesSelection)
                {
                    case ChromosomesSelection.Elitarism:
                        for(int i = 0;i< eliteSize;i++)
                        {
                            newPopulation.Add(population.Parents[i]);
                        }
                        crossOverPopulation = population.Parents;

                        break;
                    case ChromosomesSelection.ElitarismAndBestCrossOver:
                        for (int i = 0; i < eliteSize; i++)
                        {
                            newPopulation.Add(population.Parents[i]);
                        }
                        crossOverPopulation = population.SelectBests(populationSize / 2);

                        break;
                    case ChromosomesSelection.BestCrossOver:
                        crossOverPopulation = population.SelectBests(populationSize / 2);
                        break;
                    case ChromosomesSelection.AllCrossOver:
                        crossOverPopulation = population.Parents;
                        break;
                    case ChromosomesSelection.ElitarismAndRoulette:
                        for (int i = 0; i < eliteSize; i++)
                        {
                            newPopulation.Add(population.Parents[i]);
                        }
                        crossOverPopulation = population.SelectByRoulette(false, populationSize / 2);
                        break;
                    case ChromosomesSelection.Roulette:
                        crossOverPopulation = population.SelectByRoulette(false, populationSize / 2);
                        break;
                }

                while(crossOverPopulation.Count > 0)
                {
                    int rand = random.Next(crossOverPopulation.Count);
                    Chromosome a = crossOverPopulation[rand];
                    crossOverPopulation.RemoveAt(rand);
                    rand = random.Next(crossOverPopulation.Count);
                    Chromosome b = crossOverPopulation[rand];
                    crossOverPopulation.RemoveAt(rand);

                    Chromosome childA = null, childB = null;

                    switch(crossOverType)
                    {
                        case CrossOverType.SinglePoint:
                            (childA, childB) = population.SinglePointCrossOver(a, b);
                            break;
                        case CrossOverType.NPoints:
                            (childA, childB) = population.NPointCrossOver(a, b, nPointCrossOver);
                            break;
                        case CrossOverType.DecideEveryAllel:
                            (childA, childB) = population.DecideEveryAllelCrossOver(a, b);
                            break;
                    }
                    population.Children.Add(childA);
                    population.Children.Add(childB);

                }

                // Mutation.MutateChance = do poprawienia



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

        private StringBuilder IsFinished(IList<Chromosome> chromosomes)
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
