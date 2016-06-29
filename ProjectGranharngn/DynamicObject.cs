using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace ProjectGranharngn
{

    public enum Direction {
        Up, Down, Stand, Left, Right
    }

        public abstract class DynamicObject : DrawingObject
        {
        protected float hSpeed;
        protected float vSpeed;
        protected int health;

        protected DynamicObject() : base() { health = 1; }

        protected DynamicObject(int xPos, int yPos) : base(xPos, yPos) { health = 1; }

        protected DynamicObject(int health, int xPos, int yPos, int width, int height, int hSpeed, int vSpeed) : base(xPos, yPos, width, height) {
            this.HSpeed = hSpeed;
            this.VSpeed = vSpeed;
            this.Health = health;
        }

        public virtual float HSpeed {
            get { return hSpeed; }
            set {
                if (hSpeed >= 0)
                    hSpeed = value;
                else {
                   Exception e = new Exception();
                   hSpeed = 0;
                   throw e;
                }
            }
        }
        public virtual float VSpeed
        {
            get { return vSpeed; }
            set
            {
                if (value <= 0)
                    vSpeed = 0;
                else
                {
                   vSpeed = value;
                }
            }
        }

        public virtual int Health {
            get { return health; }
            set
            {
                if (health < 0)
                {
                    health = 0;
                }
                else
                    health = value;
            }
        }
        public virtual void Move(Direction dir, long time)
        {
            if (GetInretsect != null) {
                float x = (HSpeed * time)/1000;
                float y = (VSpeed * time)/1000;
                switch (dir) {
                    case Direction.Up:
                        
                        if (GetInretsect(this, new IntersectEventArgs(DrawRect, 0, y)))
                        {
                            yPos -= y;
                        }
                        break;
                    case Direction.Down:
                        if (GetInretsect(this, new IntersectEventArgs(DrawRect, 0, y)))
                        {
                           yPos += y;
                        }
                        break;
                    case Direction.Left:
                        if (GetInretsect(this, new IntersectEventArgs(DrawRect, x, 0)))
                        {
                            xPos -= x;
                        }
                        break;
                    case Direction.Right:
                        if (GetInretsect(this, new IntersectEventArgs(DrawRect, x, 0)))
                        {
                            xPos += x;

                        }
                        break;
                }
            }
        }

        public event GetIntersectHandler GetInretsect;

        public delegate bool GetIntersectHandler(DynamicObject sender, IntersectEventArgs e);
        
    }
    public class IntersectEventArgs : EventArgs
    {
        public RectangleF rect;
        public DrawingObject IntersectedObj;
        public IntersectEventArgs(RectangleF drawRect, float x, float y)
        {
            rect = drawRect;
            rect.X += x;
            rect.Y += y;
        }
    }
}
