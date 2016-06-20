using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGranharngn
{
    public class KeyEventArgs : EventArgs {
        public ConsoleKey key;
        public KeyEventArgs(ConsoleKey key) {
            this.key = key;
        }
    }
    public class KeyEventHandler{
        public event EventHandler<KeyEventArgs> IsKeyAvilable;
        public void GetKeyState(){
            if (IsKeyAvilable != null)
            {
                IsKeyAvilable(this, new KeyEventArgs(Key));
            }
            else throw new Exception();
        }
        public static ConsoleKey Key
        {
            get
            {
                ConsoleKeyInfo key;
                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true);
                    return key.Key;
                }
                else
                {
                    return ConsoleKey.NoName;
                }
            }
        }
    }
}