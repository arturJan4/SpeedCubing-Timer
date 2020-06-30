using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
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
        CubeType TypeOfCube;

        public Statistics(CubeType cubetype)
        {
            TypeOfCube = cubetype;
            Initialize();
        }
        private void Initialize()
        {
            solves = GlobalConfig.ConnectionsList[0].LoadSolvesFromDB();
            solves = solves.FindAll(x => (x.TypeOfCube == TypeOfCube));
            solves = solves.FindAll(x => (x.IsDNF == false));
            // TODO - how to calculate BO if there is DNF?
            //orderedSolves = solves.OrderBy(x => x.SolveTime).ToList();
            Recalculate();
            
        }
        private long BestOfCalculate(int howMany)
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
        public void InitializeViewStatistics(IViewInterface view, int howMany)
        {
            ClearViewStatistics(view);
            for (int i = Math.Max(0, solves.Count - howMany); i < solves.Count; ++i)
            {
                TimeSpan x = TimeSpan.FromMilliseconds(solves[i].SolveTime);

                view.AddStatistics($"{solves[i].Id}.{x.ToString(@"hh\:mm\:ss\:ff")}");
            }
            UpdateLabels(view);
        }
        public void UpdateLabels(IViewInterface view)
        {
            view.BestValue      = (Best == -1)      ? "00:00:00:00" : TimeToString(Best);
            view.WorstValue     = (Worst == -1)     ? "00:00:00:00" : TimeToString(Worst);
            view.AverageValue   = (Average == -1)   ? "00:00:00:00" : TimeToString(Average);
            view.Bo5Value       = (BO5 == -1)       ? "00:00:00:00" : TimeToString(BO5);
            view.Bo12Value      = (BO12 == -1)      ? "00:00:00:00" : TimeToString(BO12);
        }
        private string TimeToString(long time)
        {
            TimeSpan currentTime = TimeSpan.FromMilliseconds(time);
            return currentTime.ToString(@"hh\:mm\:ss\:ff");
        }
        public void ClearViewStatistics(IViewInterface view)
        {
            view.DeleteAllStatistics();
        }
        public void Recalculate()
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
        public void AddStatistics(IViewInterface view, int howMany, Solve solve)
        {
            if (solve.TypeOfCube != TypeOfCube)
                throw new InvalidOperationException("Tried to add invalid cube type statistic to incorrect table");

            solves.Add(solve);
            if(solves.Count == 1)
            {
                Initialize();
                return;
            }

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
        }
        public void ClearStatistics()
        {
            Best = -1;
            Worst = -1;
            Average = -1;
            BO5 = -1;
            BO12 = -1;
            Sum = -1;
            Count = 0;
        }

        public void DeleteLast()
        {
            // TODO CRUD
            throw new NotImplementedException();
        }
    }
}
