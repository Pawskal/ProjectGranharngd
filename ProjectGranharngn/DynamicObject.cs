using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;


namespace ProjectGranharngn
{
        public abstract class DynamicObject : DrawingObject
        {
        protected int hSpeed;
        protected int vSpeed;
        protected int health;

        protected DynamicObject() : base() { health = 1; }

        protected DynamicObject(int xPos, int yPos) : base(xPos, yPos) { health = 1; }

        protected DynamicObject(int health, int xPos, int yPos, int width, int height, int speed) : base(xPos, yPos, width, height) {  }

        public virtual int HSpeed {
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
        public virtual int VSpeed
        {
            get { return vSpeed; }
            set
            {
                if (vSpeed >= 0)
                    vSpeed = value;
                else
                {
                   vSpeed = 0;
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
        public virtual void Move(int x, int y)
        {
            if (GetInretsect != null) {

                if (GetInretsect(this, new IntersectEventArgs(DrawRect,x,y)))
                {
                    xStartPos += x;
                    yStartPos += y;
                } 
            }
        }

        public event GetIntersectHandler GetInretsect;

        public delegate bool GetIntersectHandler(DynamicObject sender, IntersectEventArgs e);

        public override void Update()
        {

        }
    }
    public class IntersectEventArgs : EventArgs
    {
        public Rectangle rect;


        public DrawingObject IntersectedObj;
        public IntersectEventArgs(Rectangle drawRect, int x, int y)
        {
            rect = drawRect;
            rect.X += x;
            rect.Y += y;
        }
    }
}
