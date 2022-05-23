using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSI.UI_stuff;

namespace WSI.AlgorithmStuff
{
    public class Solver
    {
        public readonly CrossOverType crossOverType = CrossOverType.NPoints;
        public readonly ChromosomesSelection chromosomesSelection = ChromosomesSelection.Elitarism;
        public readonly NextPopulationSelection nextPopulationSelection = NextPopulationSelection.Best;
        private int[,] startingBoard;
        private int size;
        private readonly double lenghtMultiplier = 0.01D;
        private readonly int populationSize = 120;
        private readonly int chromosomeLength = 31;
        private readonly double acceptanceValue = 0.00D;
        private readonly double elitarismPercent = 0.1D;
        private static readonly Random random = new();
        private readonly int nPointCrossOver = 5;
        private readonly double geneticMutationChance = 0.01D;
        private readonly double evolutionaryMutationChance = 0.5D;
        private readonly double geneticAdditionChance = 0.1D;
        private readonly double evolutionaryAdditionChance = 0.2D;
        private int blankX = -1;
        private int blankY = -1;

        private Population.Del fitnessFunction;
        private delegate (double, int[,], int, int) Del(Chromosome chromosome, int[,] lastBoard, int tempBlankX, int tempBlankY, int moveIndex);
        private Del fitnessFunctionSubStrings;

        public Solver(Board board)
        {
            fitnessFunction = FitnessFunctionManhattanDistanceSubStrings;
            fitnessFunctionSubStrings = FitnessFunctionManhattanDistance;
            size = board.size;
            startingBoard = new int[size, size];

            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    startingBoard[i, j] = board.tiles[i, j].OriginalHeightPosition*board.size + board.tiles[i, j].OriginalWidthPosition;
                    if(startingBoard[i, j] == size*size - 1)
                    {
                        blankX = i;
                        blankY = j;
                    }
                }
            }

            Chromosome.SetBoardProperties(size, size, blankX, blankY);
        }

        public async Task<(StringBuilder, int, StringBuilder, int)> SolvePuzzle(int maxIterations, AlgorithmChoice choice) // returns solution and number of iterations (optionaly solution and number of iterations for second algorith, default evolutionary)
        {
            switch(choice)
            {
                case AlgorithmChoice.Genetic:
                    var resultGenetic = GeneticAlgorithm(maxIterations);
                    return (resultGenetic.Item1, resultGenetic.Item2, null, 0);
                case AlgorithmChoice.Evolution:
                    var resultEvolutionary = EvolutionaryAlgorithm(maxIterations);
                    return (resultEvolutionary.Item1, resultEvolutionary.Item2, null, 0);
                case AlgorithmChoice.Both:
                    var geneticTask = Task.Run(() => GeneticAlgorithm(maxIterations));
                    var evolutionaryTask = Task.Run(() => EvolutionaryAlgorithm(maxIterations));
                    var resultGeneticBoth = await geneticTask;
                    var resultEvolutionaryBoth = await evolutionaryTask;
                    return (resultGeneticBoth.Item1, resultGeneticBoth.Item2, resultEvolutionaryBoth.Item1, resultEvolutionaryBoth.Item2);
            }

            return (null, 0, null, 0);
        }

        public (StringBuilder, int) GeneticAlgorithm(int maxIterations)
        {
            Population population = new Population();
            population.FitnessFunction = fitnessFunction;
            population.Children = new List<Chromosome>();
            population.Parents = Init.GetStartngChromosomes(populationSize, chromosomeLength);
            IList<Chromosome> newPopulation = new List<Chromosome>();
            IList<Chromosome> crossOverPopulation = new List<Chromosome>();
            int eliteSize = 0;
            Mutation.MutateChance = geneticMutationChance;
            Mutation.AddVsMutateChance = geneticAdditionChance;

            int iterationCount = 1;
            while (iterationCount <= maxIterations)
            {
                population.Parents = population.Sort(population.Parents);
                (StringBuilder isFinished, double fitness) = IsFinished(population.Parents);
                if (isFinished != null)
                {
                    Debug.WriteLine($"Genetic solution iteration: {iterationCount} best fitness: {fitness}");
                    return (isFinished, iterationCount);
                }

                population.Children.Clear();
                newPopulation.Clear();
                Debug.WriteLine($"Genetic iteration: {iterationCount} best fitness: {fitness}");

                // cross over
                switch (chromosomesSelection)
                {
                    case ChromosomesSelection.Elitarism:
                        eliteSize = (int)(elitarismPercent * populationSize);
                        for (int i = 0;i< eliteSize;i++)
                        {
                            newPopulation.Add(population.Parents[i].DeepCopy());
                        }
                        crossOverPopulation = population.Parents;

                        break;
                    case ChromosomesSelection.ElitarismAndBestCrossOver:
                        eliteSize = (int)(elitarismPercent * populationSize);
                        for (int i = 0; i < eliteSize; i++)
                        {
                            newPopulation.Add(population.Parents[i].DeepCopy());
                        }
                        crossOverPopulation = population.SelectBests(populationSize / 2);

                        break;
                    case ChromosomesSelection.BestCrossOver:
                        crossOverPopulation = population.SelectBests(populationSize / 2);
                        break;
                    case ChromosomesSelection.AllCrossOver:
                        crossOverPopulation = new List<Chromosome>(population.Parents);
                        break;
                    case ChromosomesSelection.ElitarismAndRoulette:
                        eliteSize = (int)(elitarismPercent * populationSize);
                        for (int i = 0; i < eliteSize; i++)
                        {
                            newPopulation.Add(population.Parents[i].DeepCopy());
                        }
                        crossOverPopulation = population.SelectByRoulette(true, populationSize / 2);
                        break;
                    case ChromosomesSelection.Roulette:
                        crossOverPopulation = population.SelectByRoulette(true, populationSize / 2);
                        break;
                }

                population.Parents = new List<Chromosome>(crossOverPopulation);

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
                    childA.sequence = childA.Correct();
                    childB.sequence = childB.Correct();
                    population.Children.Add(childA);
                    population.Children.Add(childB);
                }

                for(int i = 0; i < population.Children.Count; i++)
                {
                    Mutation.Mutate(population.Children[i]);
                }

                IList<Chromosome> candidates = new List<Chromosome>();
                /*IList<Chromosome> candidates = new List<Chromosome>();
                for(int i = 0;i< population.Children.Count; i++)
                {
                    candidates.Add(population.Children[i]);
                }*/

                switch (nextPopulationSelection)
                {
                    case NextPopulationSelection.Children:
                        //population.Children = candidates;
                        if (population.Children.Count < populationSize)
                            throw new ArgumentException();
                        candidates = population.SelectChildren(populationSize - eliteSize);
                        for(int i = 0; i< candidates.Count; i++)
                        {
                            newPopulation.Add(candidates[i].DeepCopy());
                        }
                        break;
                    case NextPopulationSelection.RouletteChildren:
                        //population.Children = candidates;
                        if (population.Children.Count < populationSize)
                            throw new ArgumentException();
                        candidates = population.SelectByRoulette(false, populationSize - eliteSize);
                        for (int i = 0; i < candidates.Count; i++)
                        {
                            newPopulation.Add(candidates[i].DeepCopy());
                        }
                        break;
                    case NextPopulationSelection.Roulette:
                        //population.Children = candidates;
                        candidates = population.SelectByRoulette(true, populationSize - eliteSize);
                        for(int i = 0;i< candidates.Count; i++)
                        {
                            newPopulation.Add(candidates[i].DeepCopy());
                        }
                        break;
                    case NextPopulationSelection.Best:
                        //population.Children = candidates;
                        candidates = population.SelectBests(populationSize - eliteSize);
                        for (int i = 0; i < candidates.Count; i++)
                        {
                            newPopulation.Add(candidates[i].DeepCopy());
                        }
                        break;
                }

                population.Parents = new List<Chromosome>(newPopulation);

                iterationCount++;
            }

            population.Parents = population.Sort(population.Parents);

            double bestFitness = double.MaxValue;
            StringBuilder bestSolution = new StringBuilder();
            foreach (Chromosome chromosome in population.Parents)
            {
                int[,] board = startingBoard.Clone() as int[,];
                int tempBlankX = blankX;
                int tempBlankY = blankY;
                double fitness = 0;
                for (int i = 0; i < chromosome.Length; i++)
                {
                    (fitness, board, tempBlankX, tempBlankY) = fitnessFunctionSubStrings(chromosome, board, tempBlankX, tempBlankY, i);
                    if(bestFitness > fitness)
                    {
                        bestFitness = fitness;
                        bestSolution = new StringBuilder(chromosome.sequence.ToString().Substring(0, i + 1));
                    }
                }
            }

            Debug.WriteLine($"Genetic final solution fitness: {bestFitness}");

            return (bestSolution, iterationCount);
        }

        public (StringBuilder, int) EvolutionaryAlgorithm(int maxIterations)
        {
            Population population = new Population();
            population.FitnessFunction = fitnessFunction;
            population.Children = new List<Chromosome>();
            population.Parents = Init.GetStartngChromosomes(populationSize, chromosomeLength);
            IList<Chromosome> newPopulation = new List<Chromosome>();
            int eliteSize = 0;
            Mutation.MutateChance = evolutionaryMutationChance;
            Mutation.AddVsMutateChance = evolutionaryAdditionChance;

            int iterationCount = 1;
            while (iterationCount <= maxIterations)
            {
                population.Parents = population.Sort(population.Parents);
                (StringBuilder isFinished, double fitness) = IsFinished(population.Parents);
                if (isFinished != null)
                {
                    Debug.WriteLine($"Evolutionary solution iteration: {iterationCount} best fitness: {fitness}");
                    return (isFinished, iterationCount);
                }

                population.Children.Clear();
                newPopulation.Clear();
                Debug.WriteLine($"Evolutionary iteration: {iterationCount} best fitness: {fitness}");

                switch (chromosomesSelection)
                {
                    case ChromosomesSelection.Elitarism:
                        eliteSize = (int)(elitarismPercent * populationSize);
                        for (int i = 0; i < eliteSize; i++)
                        {
                            newPopulation.Add(population.Parents[i].DeepCopy());
                        }

                        break;
                    case ChromosomesSelection.ElitarismAndBestCrossOver:
                        eliteSize = (int)(elitarismPercent * populationSize);
                        for (int i = 0; i < eliteSize; i++)
                        {
                            newPopulation.Add(population.Parents[i].DeepCopy());
                        }
                        break;
                    case ChromosomesSelection.BestCrossOver:
                        break;
                    case ChromosomesSelection.AllCrossOver:
                        break;
                    case ChromosomesSelection.ElitarismAndRoulette:
                        eliteSize = (int)(elitarismPercent * populationSize);
                        for (int i = 0; i < eliteSize; i++)
                        {
                            newPopulation.Add(population.Parents[i].DeepCopy());
                        }
                        break;
                    case ChromosomesSelection.Roulette:
                        break;
                }

                population.Children = new List<Chromosome>(population.Parents);

                population.Parents = new List<Chromosome>();

                for (int i = 0; i < population.Children.Count; i++)
                {
                    Mutation.Mutate(population.Children[i]);
                }

                IList<Chromosome> candidates = new List<Chromosome>();
                /*for (int i = 0; i < population.Children.Count; i++)
                {
                    candidates.Add(population.Children[i]);
                }*/

                switch (nextPopulationSelection)
                {
                    case NextPopulationSelection.Children:
                        //population.Children = candidates;
                        if (population.Children.Count < populationSize)
                            throw new ArgumentException();
                        candidates = population.SelectChildren(populationSize - eliteSize);
                        for (int i = 0; i < candidates.Count; i++)
                        {
                            newPopulation.Add(candidates[i].DeepCopy());
                        }
                        break;
                    case NextPopulationSelection.RouletteChildren:
                        //population.Children = candidates;
                        if (population.Children.Count < populationSize)
                            throw new ArgumentException();
                        candidates = population.SelectByRoulette(false, populationSize - eliteSize);
                        for (int i = 0; i < candidates.Count; i++)
                        {
                            newPopulation.Add(candidates[i].DeepCopy());
                        }
                        break;
                    case NextPopulationSelection.Roulette:
                        candidates = population.SelectByRoulette(true, populationSize - eliteSize);
                        for (int i = 0; i < candidates.Count; i++)
                        {
                            newPopulation.Add(candidates[i].DeepCopy());
                        }
                        break;
                    case NextPopulationSelection.Best:
                        candidates = population.SelectBests(populationSize - eliteSize);
                        for (int i = 0; i < candidates.Count; i++)
                        {
                            newPopulation.Add(candidates[i].DeepCopy());
                        }
                        break;
                }

                population.Parents = new List<Chromosome>(newPopulation);

                iterationCount++;
            }

            population.Parents = population.Sort(population.Parents);

            double bestFitness = double.MaxValue;
            StringBuilder bestSolution = new StringBuilder();
            foreach (Chromosome chromosome in population.Parents)
            {
                int[,] board = startingBoard.Clone() as int[,];
                int tempBlankX = blankX;
                int tempBlankY = blankY;
                double fitness = 0;
                for (int i = 0; i < chromosome.Length; i++)
                {
                    (fitness, board, tempBlankX, tempBlankY) = fitnessFunctionSubStrings(chromosome, board, tempBlankX, tempBlankY, i);
                    if (bestFitness > fitness)
                    {
                        bestFitness = fitness;
                        bestSolution = new StringBuilder(chromosome.sequence.ToString().Substring(0, i + 1));
                    }
                }
            }

            Debug.WriteLine($"Evolutionary final solution fitness: {bestFitness}");

            return (bestSolution, iterationCount);
        }

        private (StringBuilder, double) IsFinished(IList<Chromosome> chromosomes)
        {
            double bestFitness = double.MaxValue;
            foreach (Chromosome chromosome in chromosomes)
            {
                int [,] board = startingBoard.Clone() as int[,];
                int tempBlankX = blankX;
                int tempBlankY = blankY;
                double fitness = 0;
                for (int i = 0; i < chromosome.Length; i++)
                {
                    (fitness, board, tempBlankX, tempBlankY) = fitnessFunctionSubStrings(chromosome, board, tempBlankX, tempBlankY, i);
                    bestFitness = Math.Min(fitness, bestFitness);
                    if (fitness <= acceptanceValue)
                    {
                        //StringBuilder result = new StringBuilder();
                        // corrected chromosome and return result
                        return (new StringBuilder(chromosome.sequence.ToString().Substring(0, i + 1)), fitness);
                    }
                }
            }

            /*
            int[,] board = startingBoard.Clone() as int[,];
            int tempBlankX = blankX;
            int tempBlankY = blankY;
            double distance = 0;
            for (int i = 0; i < chromosomes[0].Length; i++)
            {
                (distance, board, tempBlankX, tempBlankY) = fitnessFunctionSubStrings(chromosomes[0], board, tempBlankX, tempBlankY, i);
                if (distance <= acceptanceValue)
                {
                    //StringBuilder result = new StringBuilder();
                    // corrected chromosome and return result
                    return new StringBuilder(chromosomes[0].sequence.ToString().Substring(0, i + 1));
                }
            }*/

            return (null, bestFitness);
        }

        private (double, int[,], int, int) FitnessFunctionManhattanDistance(Chromosome chromosome, int[,] lastBoard, int tempBlankX, int tempBlankY, int moveIndex)
        {
            (lastBoard, tempBlankX, tempBlankY) = ApplyMove(chromosome, lastBoard, tempBlankX, tempBlankY, moveIndex);
            double distance = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    distance += Math.Abs(lastBoard[i, j] / size - j) + Math.Abs(lastBoard[i, j] % size - i);
                }
            }
            //distance /= size * size;
            distance += (moveIndex + 1) * lenghtMultiplier;
            return (distance, lastBoard, tempBlankX, tempBlankY);
        }

        private double FitnessFunctionManhattanDistance(Chromosome chromosome)
        {
            double distance = 0;
            int [,] board = ApplyMoves(chromosome);
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    distance += Math.Abs(board[i,j]/size - j) + Math.Abs(board[i,j]%size - i);
                }
            }
            //distance /= size * size;
            distance += chromosome.Length * lenghtMultiplier;
            return distance;
        }

        private double FitnessFunctionManhattanDistanceSubStrings(Chromosome chromosome)
        {
            double bestFitness = double.MaxValue;
            int[,] board = startingBoard.Clone() as int[,];
            int tempBlankX = blankX;
            int tempBlankY = blankY;
            double fitness;
            for (int moveIndex = 0; moveIndex < chromosome.Length; moveIndex++)
            {
                (board, tempBlankX, tempBlankY) = ApplyMove(chromosome, board, tempBlankX, tempBlankY, moveIndex);
                fitness = 0;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        fitness += Math.Abs(board[i, j] / size - j) + Math.Abs(board[i, j] % size - i);
                    }
                }
                //distance /= size * size;
                fitness += (moveIndex + 1) * lenghtMultiplier;

                if(bestFitness > fitness)
                {
                    bestFitness = fitness;
                }
            }
            return bestFitness;
        }

        private (double, int[,], int, int) FitnessFunctionEuclideanDistance(Chromosome chromosome, int[,] lastBoard, int tempBlankX, int tempBlankY, int moveIndex)
        {
            (lastBoard, tempBlankX, tempBlankY) = ApplyMove(chromosome, lastBoard, tempBlankX, tempBlankY, moveIndex);
            double distance = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    distance += Math.Pow(lastBoard[i, j] / size - j, 2) + Math.Pow(lastBoard[i, j] % size - i, 2);
                }
            }
            //distance /= size * size;
            distance += (moveIndex + 1) * lenghtMultiplier;
            return (distance, lastBoard, tempBlankX, tempBlankY);
        }

        private double FitnessFunctionEuclideanDistance(Chromosome chromosome)
        {
            double distance = 0;
            int[,] board = ApplyMoves(chromosome);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    distance += Math.Pow(board[i, j] / size - j, 2) + Math.Pow(board[i, j] % size - i, 2);
                }
            }
            //distance /= size * size;
            distance += chromosome.Length * lenghtMultiplier;
            return distance;
        }

        private double FitnessFunctionEuclideanDistanceSubStrings(Chromosome chromosome)
        {
            double bestFitness = double.MaxValue;
            int[,] board = startingBoard.Clone() as int[,];
            int tempBlankX = blankX;
            int tempBlankY = blankY;
            double fitness;
            for (int moveIndex = 0; moveIndex < chromosome.Length; moveIndex++)
            {
                (board, tempBlankX, tempBlankY) = ApplyMove(chromosome, board, tempBlankX, tempBlankY, moveIndex);
                fitness = 0;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        fitness += Math.Pow(board[i, j] / size - j, 2) + Math.Pow(board[i, j] % size - i, 2);
                    }
                }
                //distance /= size * size;
                fitness += (moveIndex + 1) * lenghtMultiplier;

                if (bestFitness > fitness)
                {
                    bestFitness = fitness;
                }
            }
            return bestFitness;
        }

        private (int[,], int, int) ApplyMove(Chromosome chromosome, int[,] board, int tempBlankX, int tempBlankY, int index)
        {
            switch((Allel)chromosome.sequence[index])
            {
                case Allel.D:
                    board[tempBlankX, tempBlankY] = board[tempBlankX, tempBlankY + 1];
                    board[tempBlankX, tempBlankY + 1] = size*size - 1;
                    tempBlankY++;
                    break;
                case Allel.U:
                    board[tempBlankX, tempBlankY] = board[tempBlankX, tempBlankY - 1];
                    board[tempBlankX, tempBlankY - 1] = size * size - 1;
                    tempBlankY--;
                    break;
                case Allel.R:
                    board[tempBlankX, tempBlankY] = board[tempBlankX + 1, tempBlankY];
                    board[tempBlankX + 1, tempBlankY] = size * size - 1;
                    tempBlankX++;
                    break;
                case Allel.L:
                    board[tempBlankX, tempBlankY] = board[tempBlankX - 1, tempBlankY];
                    board[tempBlankX - 1, tempBlankY] = size * size - 1;
                    tempBlankX--;
                    break;
            }
            return (board, tempBlankX, tempBlankY);
        }

        private int[,] ApplyMoves(Chromosome chromosome)
        {
            int[,] board = startingBoard.Clone() as int[,];
            int blank = size * size - 1;
            int tempBlankX = blankX;
            int tempBlankY = blankY;

            foreach (Allel move in chromosome.sequence.ToString())
            {
                switch (move)
                {
                    case Allel.D:
                        board[tempBlankX, tempBlankY] = board[tempBlankX, tempBlankY + 1];
                        board[tempBlankX, tempBlankY + 1] = blank;
                        tempBlankY++;
                        break;
                    case Allel.U:
                        board[tempBlankX, tempBlankY] = board[tempBlankX, tempBlankY - 1];
                        board[tempBlankX, tempBlankY - 1] = blank;
                        tempBlankY--;
                        break;
                    case Allel.R:
                        board[tempBlankX, tempBlankY] = board[tempBlankX + 1, tempBlankY];
                        board[tempBlankX + 1, tempBlankY] = blank;
                        tempBlankX++;
                        break;
                    case Allel.L:
                        board[tempBlankX, tempBlankY] = board[tempBlankX - 1, tempBlankY];
                        board[tempBlankX - 1, tempBlankY] = blank;
                        tempBlankX--;
                        break;
                }
            }
            return board;
        }

    }
}
