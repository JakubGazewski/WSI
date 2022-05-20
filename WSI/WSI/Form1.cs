using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSI.AlgorithmStuff;
using WSI.UI_stuff;

namespace WSI
{
    public partial class Form1 : Form
    {
        private Board board;
        private Bitmap boardImage;
        private Size pictureSize = new Size(600, 600);
        private StringBuilder geneticSolution = null;
        private StringBuilder evolutionSolution = null;
        private AlgorithmChoice currentCheckedAlgorithm = AlgorithmChoice.None;
        private StringBuilder currentCheckedSolution = null;
        private int currentCheckedStep;
        private Board originalSolutionBoard;
        public Form1()
        {
            InitializeComponent();
            boardImage = new Bitmap(Properties.Resources.exampleImage);
            boardImage = new Bitmap(boardImage, pictureSize);
            board = new Board((int)BoardSizeNumericUpDown.Value, boardImage);
        }
        private void BoardSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            board = new Board((int)BoardSizeNumericUpDown.Value, boardImage);
            boardPictureBox.Invalidate();
        }
        private void boardPictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            board.DrawBoard(g, 10, 10);
        }

        private void shuffleButton_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int move;
            for(int i = 0; i < 100; i++)
            {
                move = r.Next(0, 4);
                board.Move((Moves)move);
            }
            boardPictureBox.Invalidate();
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            board.Move(Moves.Up);
            boardPictureBox.Invalidate();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            board.Move(Moves.Left);
            boardPictureBox.Invalidate();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            board.Move(Moves.Down);
            boardPictureBox.Invalidate();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            board.Move(Moves.Right);
            boardPictureBox.Invalidate();
        }

        private void maxNumberOfIterationsNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            iterationLabel.Text = "Iterations: 0/" + maxNumberOfIterationsNumericUpDown.Value.ToString();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            geneticAlgorithmRadioButton.Enabled = false;
            evolutionAlgorithmRadioButton.Enabled = false;
            bothAlgorithmsRadioButton.Enabled = false;
            maxNumberOfIterationsNumericUpDown.Enabled = false;
            BoardSizeNumericUpDown.Enabled = false;
            shuffleButton.Enabled = false;
            upButton.Enabled = false;
            leftButton.Enabled = false;
            downButton.Enabled = false;
            rightButton.Enabled = false;
            startButton.Enabled = false;
            AlgorithmChoice algoChoice;
            if (geneticAlgorithmRadioButton.Checked) algoChoice = AlgorithmChoice.Genetic;
            else if (evolutionAlgorithmRadioButton.Checked) algoChoice = AlgorithmChoice.Evolution;
            else algoChoice = AlgorithmChoice.Both;
            someCalculationFunction(algoChoice, (int)maxNumberOfIterationsNumericUpDown.Value);
        }
        private void someCalculationFunction(AlgorithmChoice choice, int maxIterations)
        {
            Solver puzzleSolver = new Solver(board);
            StringBuilder solution1;
            int solution1Steps;
            StringBuilder solution2;
            int solution2Steps;
            (solution1, solution1Steps, solution2, solution2Steps) = puzzleSolver.SolvePuzzle(maxIterations, choice).Result;
            switch(choice)
            {
                case AlgorithmChoice.Genetic:
                    geneticUsedIterationsLabel.Text = "Steps: " + solution1Steps;
                    geneticResultSelectButton.Enabled = true;
                    geneticSolution = solution1;
                    currentCheckedAlgorithm = AlgorithmChoice.Genetic;
                    currentCheckedSolution = geneticSolution;
                    break;
                case AlgorithmChoice.Evolution:
                    evolutionUsedIterationsLabel.Text = "Steps: " + solution1Steps;
                    evolutionResultSelectionButton.Enabled = true;
                    evolutionSolution = solution1;
                    currentCheckedAlgorithm = AlgorithmChoice.Evolution;
                    currentCheckedSolution = evolutionSolution;
                    break;
                case AlgorithmChoice.Both:
                    geneticUsedIterationsLabel.Text = "Steps: " + solution1Steps;
                    geneticResultSelectButton.Enabled = true;
                    geneticSolution = solution1;
                    evolutionUsedIterationsLabel.Text = "Steps: " + solution2Steps;
                    evolutionResultSelectionButton.Enabled = true;
                    evolutionSolution = solution2;
                    currentCheckedAlgorithm = AlgorithmChoice.Genetic;
                    currentCheckedSolution = geneticSolution;
                    break;
                case AlgorithmChoice.None:
                    break;
            }
            currentCheckedStep = 0;
            originalSolutionBoard = board.deepCopy();
            endCheckingSolutionButton.Enabled = true;
            leftStepButton.Enabled = true;
            rightStepButton.Enabled = true;
            /*geneticAlgorithmRadioButton.Enabled = true;
            evolutionAlgorithmRadioButton.Enabled = true;
            bothAlgorithmsRadioButton.Enabled = true;
            maxNumberOfIterationsNumericUpDown.Enabled = true;
            BoardSizeNumericUpDown.Enabled = true;
            shuffleButton.Enabled = true;
            upButton.Enabled = true;
            leftButton.Enabled = true;
            downButton.Enabled = true;
            rightButton.Enabled = true;
            startButton.Enabled = true;*/
            updateSolutionScroller();
        }
        private void updateSolutionScroller()
        {
            board = originalSolutionBoard.deepCopy();
            currentCheckedStep = 0;
            switch (currentCheckedAlgorithm)
            {
                case AlgorithmChoice.Genetic:
                    stepLabel.Text = "Step 0/" + geneticSolution.Length;
                    currentCheckedSolution = geneticSolution;
                    break;
                case AlgorithmChoice.Evolution:
                    stepLabel.Text = "Step 0/" + evolutionSolution.Length;
                    currentCheckedSolution = evolutionSolution;
                    break;
            }
            leftStepButton.Enabled = false;
            if (currentCheckedSolution.Length == 0) rightStepButton.Enabled = false;
            boardPictureBox.Invalidate();
        }
        private Moves translateMove(char c)
        {
            switch(c)
            {
                case 'U':
                    return Moves.Up;
                case 'D':
                    return Moves.Down;
                case 'L':
                    return Moves.Left;
                case 'R':
                    return Moves.Right;
                default:
                    throw new ArgumentException();
            }
        }
        private Moves negateMove(Moves moveToNegate)
        {
            switch(moveToNegate)
            {
                case Moves.Up:
                    return Moves.Down;
                case Moves.Down:
                    return Moves.Up;
                case Moves.Left:
                    return Moves.Right;
                case Moves.Right:
                    return Moves.Left;
                default:
                    throw new ArgumentException();
            }
        }
        private void leftStepButton_Click(object sender, EventArgs e)
        {
            char moveInChar = currentCheckedSolution[currentCheckedStep - 1];
            Moves moveToMake = translateMove(moveInChar);
            moveToMake = negateMove(moveToMake);
            board.Move(moveToMake);
            currentCheckedStep--;
            if (currentCheckedStep == 0) leftButton.Enabled = false;
            if (currentCheckedStep != currentCheckedSolution.Length) rightStepButton.Enabled = true;
            boardPictureBox.Invalidate();
        }
        private void rightStepButton_Click(object sender, EventArgs e)
        {
            char moveInChar = currentCheckedSolution[currentCheckedStep];
            Moves moveToMake = translateMove(moveInChar);
            board.Move(moveToMake);
            currentCheckedStep++;
            if (currentCheckedStep == currentCheckedSolution.Length) rightStepButton.Enabled = false;
            if (currentCheckedStep != 0) leftButton.Enabled = true;
            boardPictureBox.Invalidate();
        }

        private void geneticResultSelectButton_Click(object sender, EventArgs e)
        {
            currentCheckedAlgorithm = AlgorithmChoice.Genetic;
            updateSolutionScroller();
        }

        private void evolutionResultSelectionButton_Click(object sender, EventArgs e)
        {
            currentCheckedAlgorithm = AlgorithmChoice.Evolution;
            updateSolutionScroller();
        }

        private void endCheckingSolutionButton_Click(object sender, EventArgs e)
        {
            endCheckingSolutionButton.Enabled = false;
            endCheckingSolutionButton.Enabled = false;
            leftStepButton.Enabled = false;
            rightStepButton.Enabled = false;
            geneticUsedIterationsLabel.Text = "Steps:";
            geneticResultSelectButton.Enabled = false;
            geneticSolution = null;
            evolutionUsedIterationsLabel.Text = "Steps:";
            evolutionResultSelectionButton.Enabled = false;
            evolutionSolution = null;
            currentCheckedAlgorithm = AlgorithmChoice.None;
            currentCheckedSolution = null;
            board = new Board((int)BoardSizeNumericUpDown.Value, boardImage);
            boardPictureBox.Invalidate();
            currentCheckedStep = 0;

            geneticAlgorithmRadioButton.Enabled = true;
            evolutionAlgorithmRadioButton.Enabled = true;
            bothAlgorithmsRadioButton.Enabled = true;
            maxNumberOfIterationsNumericUpDown.Enabled = true;
            BoardSizeNumericUpDown.Enabled = true;
            shuffleButton.Enabled = true;
            upButton.Enabled = true;
            leftButton.Enabled = true;
            downButton.Enabled = true;
            rightButton.Enabled = true;
            startButton.Enabled = true;
        }
    }
}
