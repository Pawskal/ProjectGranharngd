using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGranharngn
{
    public interface IControlable
    {
        void KeyAction(object sender, KeyEventArgs e);
    }
}
