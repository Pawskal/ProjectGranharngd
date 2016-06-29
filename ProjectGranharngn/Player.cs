using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGranharngn
{
    public class Player : DynamicObject, IControlable
    {
        public Player() : base() {  }

        public Player(int xPos, int yPos) : base(xPos, yPos) {  }

        public Player(int health, int xPos, int yPos, int width, int height, int hSpeed, int vSpeed) : base(health, xPos, yPos, width, height, hSpeed, vSpeed) {
            for (int i = 0; i < this.Width; i++)
            {
                for (int j = 0; j < this.Height; j++)
                {
                    this.data[i, j].symbol = '#';
                    this.data[i, j].symbolColor = ConsoleColor.Green;
                    this.data[i, j].backgroundColor = ConsoleColor.Black;
                }
            }
            
        }

        public void KeyAction(object sender, KeyEventArgs e)
        {
            switch (e.key)
            {
                case ConsoleKey.DownArrow:
                        Move(Direction.Down, e.pressedTime);
                    break;
                case ConsoleKey.LeftArrow:
                        Move(Direction.Left, e.pressedTime);
                    break;
                case ConsoleKey.RightArrow:
                        Move(Direction.Right, e.pressedTime);
                    break;
                case ConsoleKey.UpArrow:
                        Move(Direction.Up, e.pressedTime);
                    break;
                default:
                    break;
            }
        }
    }
}
