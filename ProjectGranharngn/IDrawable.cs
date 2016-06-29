using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ProjectGranharngn
{
    public interface IDrawable
    {
        ObjectData this[int i, int j]
        {
            get;
        }

        RectangleF DrawRect { get; set; }
    }
}
