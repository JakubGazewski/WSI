using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSI.UI_stuff
{
    public class Board
    {
        public Tile[,] tiles;
        public Bitmap image;
        public int emptyTileX;
        public int emptyTileY;
        public int size;
        public Board(int size, Bitmap image)
        {
            this.size = size;
            this.image = image;
            tiles = new Tile[size, size];
            for(int x = 0; x < size; x++)
            {
                for(int y = 0; y < size; y++)
                {
                    if(x == size - 1 && y == size - 1)
                    {
                        tiles[x, y] = new Tile(null, x, y, size);
                    }
                    else
                    {
                        tiles[x, y] = new Tile(new Bitmap(image), x, y, size);
                    }
                }
            }
            emptyTileX = size - 1;
            emptyTileY = size - 1;
        }
        public void DrawBoard(Graphics g, int boardUpperLeftCornerX, int boardUpperLeftCornerY)
        {
            double squareSize = image.Width / tiles.GetLength(0);
            Pen blackPen = new Pen(Color.Black);
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for(int j = 0; j < tiles.GetLength(1); j++)
                {
                    tiles[i, j].drawTile(g, boardUpperLeftCornerX, boardUpperLeftCornerY);
                }
            }
            for (int i = 0; i <= tiles.GetLength(0); i++)
            {
                g.DrawLine(blackPen, boardUpperLeftCornerX + (int)(i * squareSize), boardUpperLeftCornerY, boardUpperLeftCornerX + (int)(i * squareSize), boardUpperLeftCornerY + image.Height);
            }
            for (int j = 0; j <= tiles.GetLength(1); j++)
            {
                g.DrawLine(blackPen, boardUpperLeftCornerX, boardUpperLeftCornerY + (int)(j * squareSize), boardUpperLeftCornerX + image.Height, boardUpperLeftCornerY + (int)(j * squareSize));
            }
        }
        public bool Move(Moves moveToMake)
        {
            Tile a, b, temp;
            switch(moveToMake)
            {
                case Moves.Up:
                    if (emptyTileY - 1 < 0) return false;
                    a = tiles[emptyTileX, emptyTileY];
                    b = tiles[emptyTileX, emptyTileY - 1];
                    a.HeightPosition -= 1;
                    b.HeightPosition += 1;
                    temp = tiles[emptyTileX, emptyTileY];
                    tiles[emptyTileX, emptyTileY] = tiles[emptyTileX, emptyTileY - 1];
                    tiles[emptyTileX, emptyTileY - 1] = temp;
                    emptyTileY -= 1;
                    return true;
                case Moves.Down:
                    if (emptyTileY + 1 >= tiles.GetLength(0)) return false;
                    a = tiles[emptyTileX, emptyTileY];
                    b = tiles[emptyTileX, emptyTileY + 1];
                    a.HeightPosition += 1;
                    b.HeightPosition -= 1;
                    temp = tiles[emptyTileX, emptyTileY];
                    tiles[emptyTileX, emptyTileY] = tiles[emptyTileX, emptyTileY + 1];
                    tiles[emptyTileX, emptyTileY + 1] = temp;
                    emptyTileY += 1;
                    return true;
                case Moves.Right:
                    if (emptyTileX + 1 >= tiles.GetLength(0)) return false;
                    a = tiles[emptyTileX, emptyTileY];
                    b = tiles[emptyTileX + 1, emptyTileY];
                    a.WidthPosition += 1;
                    b.WidthPosition -= 1;
                    temp = tiles[emptyTileX, emptyTileY];
                    tiles[emptyTileX, emptyTileY] = tiles[emptyTileX + 1, emptyTileY];
                    tiles[emptyTileX + 1, emptyTileY] = temp;
                    emptyTileX += 1;
                    return true;
                case Moves.Left:
                    if (emptyTileX - 1 < 0) return false;
                    a = tiles[emptyTileX, emptyTileY];
                    b = tiles[emptyTileX - 1, emptyTileY];
                    a.WidthPosition -= 1;
                    b.WidthPosition += 1;
                    temp = tiles[emptyTileX, emptyTileY];
                    tiles[emptyTileX, emptyTileY] = tiles[emptyTileX - 1, emptyTileY];
                    tiles[emptyTileX - 1, emptyTileY] = temp;
                    emptyTileX -= 1;
                    return true;
                default: 
                    return false;
            }
        }
        public Board deepCopy()
        {
            Board result = new Board(size, image);
            return result;
        }
    }
}
