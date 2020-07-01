using System.Drawing;

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
        /// Does a start/stop action on timer.
        /// </summary>
        void TimerInteract();
        /// <summary>
        /// Current time of inspection/solving in HOURS:MINUTES:SECONDS:CENTISECONDS(1/100th of a second) format.
        /// </summary>
        string ClockTime { get; set; }
        /// <summary>
        /// Sets and gets label showing currently picked cube type.
        /// </summary>
        string CubeTypeLabelInter { get; set; }
        /// <summary>
        /// Changes color of a clock
        /// </summary>
        /// <param name="color">Color Enum (can use RGB input)</param>
        void SetClockColor(Color color);
        /// <summary>
        /// Changes color of form background
        /// </summary>
        /// <param name="color">Color Enum (can use RGB input)</param>
        void SetBackgroundColor(Color color);

        /// <summary>
        /// Adds one item to the box.
        /// </summary>
        /// <param name="item">Format: [id] time</param>
        void AddStatistics(string item);
        /// <summary>
        /// Automatically selects and scrolls to the last statistic in the box.
        /// </summary>
        void GoToLastStatistics();
        /// <summary>
        /// Clears the statistics box (without deleting statistics)
        /// </summary>
        void ClearStatisticsBox();
        /// <summary>
        /// Deletes item last inputted in current box.
        /// </summary>
        void DeleteLastStatistics();
        /// <summary>
        /// Deletes item selected in current box.
        /// </summary>
        /// <param name="selectedItem">Full string of selected item</param>
        void DeleteSelectedStatistics(string selectedItem);
        /// <summary>
        /// Deletes all statistics
        /// </summary>
        void DeleteAllStatistics();

        /// <summary>
        /// String representation of a current scramble.
        /// </summary>
        string Scramble { get; set; }
        /// <summary>
        /// Is the current solve disqualified.
        /// </summary>
        string DNF { get; set; }
        /// <summary>
        /// Best solve time for current cube type.
        /// </summary>
        string BestValue { get; set; }
        /// <summary>
        /// Worst solve time for current cube type.
        /// </summary>
        string WorstValue { get; set; }
        /// <summary>
        /// Average solve time for current cube type.
        /// </summary>
        string AverageValue { get; set; }
        /// <summary>
        /// Best of 5 (best and worst results are discarded) average. 
        /// If there are less then 5 solves it doesn't apply.
        /// </summary>
        string Bo5Value { get; set; }
        /// <summary>
        /// Best of 12 (best and worst results are discarded) average. 
        /// If there are less then 12 solves it doesn't apply.
        /// </summary>
        string Bo12Value { get; set; }
    }
}
