using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    static class Statistics
    {
        private static List<Solve> solves = new List<Solve>();
        //private static List<Solve> orderedSolves = new List<Solve>();
        public static long Best = -1;
        public static long Worst = -1;
        public static long Average = -1;
        public static long BO5 = -1;
        public static long BO12 = -1;
        public static long Sum = -1;
        public static int Count = 0;

        public static void Initialize()
        {
            solves = GlobalConfig.ConnectionsList[0].LoadSolvesFromDB();
            // TODO - how to calculate BO if there is DNF?
            //orderedSolves = solves.OrderBy(x => x.SolveTime).ToList();
            Recalculate();
        }

        private static long BestOfCalculate(int howMany)
        {
            if (Count < howMany)
                return -1;
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

        public static void InitializeViewStatistics(IViewInterface view, int howMany)
        {
            for (int i = Math.Max(0, solves.Count - howMany); i < solves.Count; ++i)
            {
                TimeSpan x = TimeSpan.FromMilliseconds(solves[i].SolveTime);

                view.AddStatistics($"{solves[i].Id}.{x.ToString(@"hh\:mm\:ss\:ff")}");
            }
        }
        public static void ClearViewStatistics(IViewInterface view)
        {
            view.DeleteAllStatistics();
        }
        public static void Recalculate()
        {
            if (solves.Count == 0)
                return;

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

        public static void AddStatistics(IViewInterface view, int howMany, Solve solve)
        {
            solves.Add(solve);

            Count = solves.Count;

            if (!solve.IsDNF)
            {
                Sum += solve.SolveTime;
                Best = Math.Min(solve.SolveTime, Best);
                Worst = Math.Max(solve.SolveTime, Worst);
            }

            Average = Sum / Count;

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

            //TODO delete first, add last
            ClearViewStatistics(view);
            InitializeViewStatistics(view, 15);
        }

        public static void ClearStatistics()
        {
            Best = -1;
            Worst = -1;
            Average = -1;
            BO5 = -1;
            BO12 = -1;
            Sum = -1;
            Count = 0;
        }
    }
}
