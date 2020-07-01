using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    /// <summary>
    /// Singleton Timer Class using System.Diagnostics.Stopwatch().
    /// Singleton because of high performance cost. Access through .Instance
    /// </summary>
    public sealed class TimerClass
    {
        private TimerClass() { }
        private static TimerClass SingletonInstance = null;
        /// <summary>
        /// Access Timer methods
        /// </summary>
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
        private Boolean isEnabled = false;
        private Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// Stops measuring time, resets the time to zero.
        /// </summary>
        public void Reset()
        {
            isEnabled = false;
            stopwatch.Reset();
        }
        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void Enable()
        {
            isEnabled = true;
            stopwatch.Start();
        }
        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Disable()
        {
            isEnabled = false;
            stopwatch.Stop();
        }
        /// <summary>
        /// Returns elapsed time as TimeSpan object.
        /// </summary>
        /// <returns>Time as TimeSpan object</returns>
        public TimeSpan GetTime()
        {
            return stopwatch.Elapsed;
        }
        /// <summary>
        /// Checks if Timer is currently counting.
        /// </summary>
        /// <returns>True if Timer is currently counting, otherwise False</returns>
        public Boolean isWorking()
        {
            return isEnabled;
        }
    }
}
