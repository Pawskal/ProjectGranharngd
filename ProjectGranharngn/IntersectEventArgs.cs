using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProjectGranharngn
{
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
