using System;
using System.Collections.Generic;

namespace TimerLibrary
{
    /// <summary>
    /// Statistics class for a given cube.
    /// Calculates certain statistics.
    /// Updates labels and statistics ListBox.
    /// </summary>
    public class Statistics
    {
        // TODO smarter seperation
        private List<Solve> solves = new List<Solve>();
        //private List<Solve> orderedSolves = new List<Solve>();
        public long Best = -1;
        public long Worst = -1;
        public long Average = -1;
        public long BO5 = -1;
        public long BO12 = -1;
        public long Sum = -1;
        public int Count = 0;
        private readonly CubeType TypeOfCube;
        /// <summary>
        /// Constructs a class given a cube type.
        /// </summary>
        /// <param name="cubetype"></param>
        public Statistics(CubeType cubetype)
        {
            TypeOfCube = cubetype;
            Initialize();
        }

        #region Output
        /// <summary>
        /// Initializes the view with elements.
        /// If there is more elements then argument howMany then it skips some statistics at the beginning.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="howMany">How many elements should be presented at once</param>
        public void InitializeViewStatistics(IViewInterface view, int howMany)
        {
            Initialize();
            view.ClearStatisticsBox();
            for (int i = Math.Max(0, solves.Count - howMany); i < solves.Count; ++i)
            {
                TimeSpan x = TimeSpan.FromMilliseconds(solves[i].SolveTime);

                int length = 5;
                string paddedId = solves[i].Id.ToString();
                int calculatePadLeft = (((length - paddedId.Length) / 2) + paddedId.Length);
                paddedId = paddedId.PadLeft(calculatePadLeft).PadRight(length);

                view.AddStatistics($"[{paddedId}] {x.ToString(@"hh\:mm\:ss\:ff")}");
            }
            UpdateLabels(view);
        }
        /// <summary>
        /// Updates averages labels.
        /// </summary>
        /// <param name="view"></param>
        public void UpdateLabels(IViewInterface view)
        {
            view.BestValue = (Best == -1) ? "00:00:00:00" : TimeToString(Best);
            view.WorstValue = (Worst == -1) ? "00:00:00:00" : TimeToString(Worst);
            view.AverageValue = (Average == -1) ? "00:00:00:00" : TimeToString(Average);
            view.Bo5Value = (BO5 == -1) ? "00:00:00:00" : TimeToString(BO5);
            view.Bo12Value = (BO12 == -1) ? "00:00:00:00" : TimeToString(BO12);
        }
        /// <summary>
        /// Returns a list of filtered statistics.
        /// </summary>
        /// <returns>List of filtered statistics</returns>
        public List<Solve> GetSolvesList()
        {
            return solves;
        }
        /// <summary>
        /// Converts time in miliseconds to formatted string
        /// </summary>
        /// <param name="time">Time in miliseconds</param>
        /// <returns>Format: HH:MM:SS:FF </returns>
        private string TimeToString(long time)
        {
            TimeSpan currentTime = TimeSpan.FromMilliseconds(time);
            return currentTime.ToString(@"hh\:mm\:ss\:ff");
        }
        /// <summary>
        /// Loads solves from file, filters for specific cubetype, discards DNF solves
        /// </summary>
        private void Initialize()
        {
            solves = GlobalConfig.ConnectionsList[0].LoadSolvesFromDB();
            solves = solves.FindAll(x => (x.TypeOfCube == TypeOfCube));
            solves = solves.FindAll(x => (x.IsDNF == false));
            // TODO - how to calculate BO if there is DNF?
            //orderedSolves = solves.OrderBy(x => x.SolveTime).ToList();
            ClearStatistics();
            Recalculate();
        }
        #endregion
        #region Calculators
        /// <summary>
        /// Recalculates stats
        /// </summary>
        public void Recalculate()
        {
            if (solves.Count == 0)
            {
                return;
            }

            Count = solves.Count;
            long sum = 0;
            Best = solves[0].SolveTime;
            Worst = solves[0].SolveTime;

            foreach (Solve s in solves)
            {
                if (!s.IsDNF)
                {
                    sum += s.SolveTime;
                    Best = Math.Min(s.SolveTime, Best);
                    Worst = Math.Max(s.SolveTime, Worst);
                }
            }
            Sum = sum;
            Average = sum / Count;

            //BO5  
            if (Count >= 5)
            {
                BO5 = BestOfCalculate(5);
            }

            //BO12
            if (Count >= 12)
            {
                BO12 = BestOfCalculate(12);
            }
        }
        /// <summary>
        /// Flexible Best of 'x' calculator.
        /// Discards best and worst and calculates average.
        /// </summary>
        /// <param name="howMany">Best Of 'howMany'</param>
        /// <returns></returns>
        private long BestOfCalculate(int howMany)
        {
            if (Count < howMany)
            {
                return -1;
            }

            long sum = 0;
            long max = solves[Count - howMany].SolveTime;
            long min = solves[Count - howMany].SolveTime;
            for (int i = Count - howMany; i < Count; ++i)
            {
                max = Math.Max(solves[i].SolveTime, max);
                min = Math.Min(solves[i].SolveTime, min);
                sum += solves[i].SolveTime;
            }
            return (sum - min - max) / (howMany - 2);
        }
        /// <summary>
        /// Resets the averages to starting values from initialization.
        /// </summary>
        private void ClearStatistics()
        {
            Best = -1;
            Worst = -1;
            Average = -1;
            BO5 = -1;
            BO12 = -1;
            Sum = -1;
            Count = 0;
        }
        #endregion
        #region Input
        // addStatistics() - adds only one / doesn't have to recalculate sum (uses already known sum)
        #endregion
    }
}
