using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProjectGranharngn
{
    class FPSCounter : Stopwatch
    {
        int fps;
        int temp;
        long frameTime;
        long lastTime;

        public static FPSCounter Instance {
            get {
                return Singleton<FPSCounter>.Instance;
            }
        }

        private FPSCounter()
        {
            fps = 0;
            temp = 0;
            lastTime = 0;
            Start();
        }

        public string GetFPS() {
            temp++;
            frameTime = ElapsedMilliseconds - lastTime;
            
            if (frameTime >= 1000)
	        {
		        fps = temp;
                temp = 0;
                lastTime = ElapsedMilliseconds;
	        }
            return "FPS: " + fps.ToString(); 
        }
    }
}
