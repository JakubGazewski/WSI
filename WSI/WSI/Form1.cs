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
            for(int i = 0; i < 3; i++)
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
            stopButton.Enabled = true;
            AlgorithmChoice algoChoice;
            if (geneticAlgorithmRadioButton.Checked) algoChoice = AlgorithmChoice.Genetic;
            else if (evolutionAlgorithmRadioButton.Checked) algoChoice = AlgorithmChoice.Evolution;
            else algoChoice = AlgorithmChoice.Both;
            someCalculationFunction(algoChoice, (int)maxNumberOfIterationsNumericUpDown.Value);
        }
        private void someCalculationFunction(AlgorithmChoice choice, int maxIterations)
        {
            for(int i = 1; i <= maxIterations; i++)
            {
                iterationLabel.Text = "Iterations: " + i +  "/" + maxNumberOfIterationsNumericUpDown.Value.ToString();
                // something something
            }
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
            stopButton.Enabled = false;
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
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
            stopButton.Enabled = false;
        }
    }
}
