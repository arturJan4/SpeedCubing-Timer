using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    // TODO - comment singleton
    public sealed class TimerClass
    {
        private TimerClass() { }
        private static TimerClass SingletonInstance = null;
        public static TimerClass Instance
        {
            get
            {
                if(SingletonInstance == null)
                {
                    SingletonInstance = new TimerClass();
                }
                return SingletonInstance;
            }
        }
        private Boolean isEnable = false;
        // TODO - check whether Stopwatch is the best option
        private Stopwatch stopwatch = new Stopwatch();
        public void Tick()
        {
            //TODO
            /*
            if (isEnable)
                TimeVal += 10;
            */   
        }
        public void Reset()
        {
            isEnable = false;
            stopwatch.Reset();
        }
        public void Enable()
        {
            isEnable = true;
            stopwatch.Start();
        }
        public void Disable()
        {
            isEnable = false;
            stopwatch.Stop();
        }
        public TimeSpan GetTime()
        {
            return stopwatch.Elapsed;
        }
    }
}
