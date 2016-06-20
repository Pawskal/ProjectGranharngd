using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGranharngn
{
    public struct ObjectData
    {
        public ConsoleColor symbolColor;
        public ConsoleColor backgroundColor;
        public char symbol;


        //public ConsoleColor SymbolColor {
        //    get { return symbolColor; }
        //}


        //public ObjectData()
        //{
        //symbol = ' ';
        //symbolColor = ConsoleColor.Black;
        //backgroundColor = ConsoleColor.Black;
        //}

        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //        return false;
        //    ObjectData buff = obj as ObjectData;
        //    if (buff == null) return false;

        //    else return ((symbolColor == buff.symbolColor) && (backgroundColor == buff.backgroundColor) && (symbol == buff.symbol));

        //}

        public override int GetHashCode()
        {
            return symbolColor.GetHashCode()^symbol.GetHashCode()^backgroundColor.GetHashCode();
        }

        public static bool operator ==(ObjectData obj1, ObjectData obj2)
        {
            //if (ReferenceEquals(obj1, obj2))
            //    return true;
            //if ((Object)obj2 == null)
            //    return false;
            return obj1.Equals(obj2);
        }

        public static bool operator !=(ObjectData obj1, ObjectData obj2)
        {
            return (!(obj1 == obj2));
        }

        //public static ObjectData operator +(ObjectData obj1, ObjectData obj2)
        //{
        //    obj1.symbol = obj2.symbol;
        //    obj1.symbolColor = obj2.symbolColor;
        //    obj1.backgroundColor = obj2.backgroundColor;

        //    return obj1;
        //}
    }
}
