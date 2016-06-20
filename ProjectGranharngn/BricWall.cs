using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGranharngn
{
    public class BricWall : Wall
    {
        public BricWall():this(1,0,0,1,1) { }

        public BricWall(int xPos, int yPos) : this(1,xPos,yPos,1,1) { }

        public BricWall(int health, int xPos, int yPos, int width, int height)
            : base(health, xPos, yPos, width, height)
        {
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    this.data[i, j].symbol = (char)176;
                    this.data[i, j].symbolColor = ConsoleColor.DarkYellow;
                    this.data[i, j].backgroundColor = ConsoleColor.Red;
                }
            }
        }
    }
}
