using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    }
}
