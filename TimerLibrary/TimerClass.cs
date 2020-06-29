using System;
using System.Collections.Generic;
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
        public long TimeVal { get; set; }
        public void Tick()
        {
            TimeVal++;
        }
        public void Reset()
        {
            TimeVal = 0;
        }
        public long GetTime()
        {
            return TimeVal;
        }
    }
}
