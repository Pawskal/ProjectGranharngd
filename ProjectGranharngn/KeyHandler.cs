using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGranharngn
{
    public class KeyEventArgs : EventArgs {
        public ConsoleKey key;
        public long pressedTime;
        public KeyEventArgs(ConsoleKey key, long pressedTime) {
            this.pressedTime = pressedTime;
            this.key = key;
        }
    }
    public class KeyEventHandler{
        public event EventHandler<KeyEventArgs> IsKeyAvilable;

        private long pressedTime;

        private long lastTime;

        ConsoleKey currentKey;

        public KeyEventHandler() {
            
            lastTime = 0;
            
        }

        public void GetKeyState(){

            currentKey = Key;

            if (currentKey != ConsoleKey.NoName) {

                pressedTime = FPSCounter.Instance.ElapsedMilliseconds - lastTime;

                IsKeyAvilable?.Invoke(this, new KeyEventArgs(currentKey, pressedTime));

            }

            lastTime = FPSCounter.Instance.ElapsedMilliseconds;


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