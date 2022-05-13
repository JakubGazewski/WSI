using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSI.UI_stuff
{
    public class Tile
    {
        public Bitmap Picture;
        public int WidthPosition;
        public int HeightPosition;
        public int OriginalWidthPosition;
        public int OriginalHeightPosition;
        public int BoardSize;
        public Tile(Bitmap picture, int widthPosition, int heightPosition, int boardSize)
        {
            Picture = picture;
            WidthPosition = OriginalWidthPosition = widthPosition;
            HeightPosition = OriginalHeightPosition = heightPosition;
            BoardSize = boardSize;
        }
        public void drawTile(Graphics g, int boardUpperLeftCornerX, int boardUpperLeftCornerY)
        {
            if (Picture == null) return;
            double squareSize = Picture.Width / BoardSize;
            int x = boardUpperLeftCornerX + (int)(squareSize * WidthPosition);
            int y = boardUpperLeftCornerY + (int)(squareSize * HeightPosition);
            g.DrawImage(Picture, x, y, new Rectangle((int)(squareSize * OriginalWidthPosition), (int)(squareSize * OriginalHeightPosition), (int)squareSize, (int)squareSize), GraphicsUnit.Pixel);
        }
    }
}
