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
        public IntersectEventArgs(Rectangle drawRect)
        {
            drawRect = this.rect;
        }
    }
}
