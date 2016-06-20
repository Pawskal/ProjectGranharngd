using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjectGranharngn
{
    public abstract class DrawingObject : IDrawable
    {

        protected Rectangle drawRect;

        protected ObjectData[,] data;

        protected DrawingObject() : this(0, 0, 1, 1 ) { }

        protected DrawingObject(int xPos, int yPos) : this(xPos, yPos, 1, 1) { }

        protected DrawingObject(int xPos, int yPos, int width, int height) {

            drawRect.X = xPos;
            drawRect.Y = yPos;
            drawRect.Width = width;
            drawRect.Height = height;

            data = new ObjectData[width, height];
        }
        
        public ObjectData this[int i, int j]
        {
            get { return data[i, j]; }
        }

        public Rectangle DrawRect { get { return drawRect; } }

        public int Width { get { return drawRect.Width; } }
        public int Height { get { return drawRect.Height; } }
        public int xStartPos { get { return drawRect.X; }
                               set {
                                   if (value < 0)
                                       {
                                         drawRect.X = 0;
                                   }
                                   else drawRect.X = value;
                                   } }
        public int yStartPos
        {
            get { return drawRect.Y; }
                               set
            {
                if (value < 0)
                {
                    drawRect.Y = 0;
                }
                else drawRect.Y = value;
            } }
    }
}
