using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGranharngn
{
    public interface IDrawable
    {
        ObjectData this[int i, int j]
        {
            get;
        }
    }
}
