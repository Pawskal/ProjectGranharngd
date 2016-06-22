using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGranharngn
{
    class Render
    {
        private const int CONSOLE_HEIGHT = 25;
        private const int CONSOLE_WIDTH = 80;
        
        private ObjectData[,] screenBuffer;
        private ObjectData[,] backBuffer;

        private bool isScreenChange;

        public static Render Instance
        {
            get
            {
                return Singleton<Render>.Instance;
            }
        }

        private Render(){

            ResizeScreen();

            isScreenChange = false;

            Console.OutputEncoding = Encoding.Default;
            Console.CursorVisible = false;

            screenBuffer = new ObjectData[CONSOLE_WIDTH, CONSOLE_HEIGHT];
            backBuffer = new ObjectData[CONSOLE_WIDTH, CONSOLE_HEIGHT];

            for (int i = 0; i < CONSOLE_WIDTH; i++)
            {
                for (int j = 0; j < CONSOLE_HEIGHT; j++)
                {
                    screenBuffer[i, j].backgroundColor = ConsoleColor.Black;
                    screenBuffer[i, j].symbolColor = ConsoleColor.Black;
                    screenBuffer[i, j].symbol = ' ';
                }
            }
            Clear();
        }

        public void DrawChar(char symbol, ConsoleColor symbolColor, ConsoleColor backgroundColor, int xPos, int yPos)
        {
            backBuffer[xPos, yPos].symbol = symbol;
            backBuffer[xPos, yPos].symbolColor = symbolColor;
            backBuffer[xPos, yPos].backgroundColor = backgroundColor;

            if (!isScreenChange)
                isScreenChange = true;
        }
        public void DrawText(String text, int xPos, int yPos) {
            Console.ResetColor();
            
            for (int i = 0; i < text.Length; i++)
            {
                DrawChar(text[i], Console.ForegroundColor, Console.BackgroundColor, xPos+i, yPos);
            }

        }
        public void Update() {
            if (isScreenChange)
            {
                for (int i = 0; i < CONSOLE_WIDTH; i++)
                {
                    for (int j = 0; j < CONSOLE_HEIGHT; j++)
                    {
                        if (screenBuffer[i, j] != backBuffer[i, j])
                        {
                            
                            screenBuffer[i, j] = backBuffer[i, j];
                            Console.SetCursorPosition(i, j);
                            Console.BackgroundColor = screenBuffer[i, j].backgroundColor;
                            Console.ForegroundColor = screenBuffer[i, j].symbolColor;
                            Console.Write(screenBuffer[i, j].symbol);
                        }
                    }
                }
                Clear();
                isScreenChange = false;
            }
        }
        public void Clear(){
            for (int i = 0; i < CONSOLE_WIDTH; i++)
            {
                for (int j = 0; j < CONSOLE_HEIGHT; j++)
                {
                    DrawChar(' ', ConsoleColor.Black, ConsoleColor.Black, i, j);
                }
            }
        }
        private void ResizeScreen() {
            Console.BufferHeight = CONSOLE_HEIGHT;
            Console.BufferWidth = CONSOLE_WIDTH;
            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight + 1);
        }
        public virtual void DrawObject(DrawingObject obj) {

            for (int i = 0; i < obj.Width; i++)
            {
                for (int j = 0; j < obj.Height; j++)
                {
                    DrawChar(obj[i, j].symbol, obj[i, j].symbolColor, obj[i, j].backgroundColor, obj.xStartPos+i, obj.yStartPos+j);
                }
            }
        }
    }
}
