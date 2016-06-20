using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGranharngn
{
    public class SteelWall : Wall
    {
        public SteelWall():this(100,0,0,1,1) { }

        public SteelWall(int xPos, int yPos) : this(100,xPos,yPos,1,1) { }

        public SteelWall(int health, int xPos, int yPos, int width, int height) : base(health, xPos, yPos, width, height) {
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    this.data[i, j].symbol = (char)CharEnum.STEELL_WALL;
                    this.data[i, j].symbolColor = ConsoleColor.White;
                    this.data[i, j].backgroundColor = ConsoleColor.DarkGray;
                }
            }
        }
    }
}
