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
        /// <summary>
        /// Current time of inspection/solving in HOURS:MINUTES:SECONDS:CENTISECONDS(1/100th of a second) format.
        /// </summary>
        string ClockTime { get; set; }
        string CubeTypeLabelInter { get; set; }
        void SetClockColor(Color color);
        void SetBackgroundColor(Color color);
        
        void AddStatistics(string item);
        void ClearStatisticsBox();
        void DeleteLastStatistics();
        void DeleteSelectedStatistics(string selectedItem);
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
        string BestValue { get; set; }
        string WorstValue { get; set; }
        string AverageValue { get; set; }
        string Bo5Value { get; set; }
        string Bo12Value { get; set; }
       




    }
}
