using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGranharngn
{
    public abstract class StaticObject : DrawingObject
    {
        protected int health;

        protected StaticObject() : base() { health = 1; }

        protected StaticObject(int xPos, int yPos) : base(xPos, yPos) { health = 1; }

        protected StaticObject(int health, int xPos, int yPos, int width, int height) : base(xPos,yPos,width,height) { this.health = health; }

        public int Health
        {
            get { return health; }
            set
            {
                if (health >= 0)
                {
                    health = value;
                }
                else
                    health = 0;
            }
        }
    }

    public abstract class Wall : StaticObject
    {
        protected Wall() : base() { }
        protected Wall(int xPos, int yPos) : base(xPos, yPos) { }
        protected Wall(int health, int xPos, int yPos, int width, int height) : base(health, xPos, yPos, width, height) { }
    }
}
