using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    /// <summary>
    /// Easy interface between Controller and View (Form).
    /// </summary>
    public interface IViewInterface
    {
        /// <summary>
        /// Links controller with the view.
        /// </summary>
        /// <param name="controller">controller to link with the current form</param>
        void SetController(Controller controller);
        /// <summary>
        /// Does a start/stop action on timer
        /// </summary>
        void TimerInteract();
        void CubeTypeChange();
        /// <summary>
        /// Current time of inspection/solving in HOURS:MINUTES:SECONDS:CENTISECONDS(1/100th of a second) format.
        /// </summary>
        string ClockTime { get; set; }
        void SetClockColor(Color color);
        void SetBackgroundColor(Color color);
        
        void AddStatistics(string item);
        void DeleteLastStatistics();
        void DeleteSelectedStatistics();
        void DeleteAllStatistics();
        
        ///List<string> Statistics { get;}
        
            /// <summary>
        /// String representation of a current scramble.
        /// </summary>
        string Scramble { get; set; }
        /// <summary>
        /// Is the current solve disqualified.
        /// </summary>
        string DNF { get; set; }


    }
}
