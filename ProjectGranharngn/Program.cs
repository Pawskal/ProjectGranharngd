using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectGranharngn {
    public static class Program {

        static bool isAcive = true;

        public static void Main(string[] args){

            Render render = Render.Instance;
            FPSCounter fpsCounter = FPSCounter.Instance;
            KeyEventHandler keyEventHandler = new KeyEventHandler();
            GameMap gameMap = new GameMap();
            
            keyEventHandler.IsKeyAvilable += gameMap.ControleObject.MoveEvent;
            keyEventHandler.IsKeyAvilable += gameMap.UpdatePosition;
            keyEventHandler.IsKeyAvilable += Program.ExitEvent;
            
            
            do
            {
                keyEventHandler.GetKeyState();

                foreach (DrawingObject item in gameMap)
                {
                    render.DrawObject(item);
                }
                render.DrawText(fpsCounter.GetFPS(), 70, 1);
                //render.DrawText(fpsCounter.ElapsedMilliseconds.ToString(), 70, 2);
                render.DrawText(gameMap.ControleObject.Health.ToString(), 70, 2);

                render.Update();

            } while (isAcive);

            render.DrawText("GAME OVER", 36, 12);
            render.Update();
                
            Console.ReadLine();
        }
        public static void ExitEvent(object sender, KeyEventArgs e) {
            if (e.key == ConsoleKey.Escape)
            {
                Program.isAcive = false;
            }
        }
    }
}