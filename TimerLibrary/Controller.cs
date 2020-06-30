using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    /// <summary>
    /// Main Controller class, arbitrates communication between
    /// Views and Models
    /// </summary>
    public class Controller
    {
        enum State
        {
            WAIT,
            INSPECT,
            SOLVE,
        }
        /* Generate Solve (and scramble)
         * Start-Timer |
         * (Inspection Timer) | 15s passed(DNF) or user stopped
         * Start-Timer |
         * (Solve Timer) | user stop
         * Update SolveTimer, DNF (maybe user input)
         * Save Solve
         * Update Stats
         */
        private State state;
        private CubeType currentCubeType;
        public Solve tempSolve;
        //TODO - solves awaiting for save (queue?)
        private Solve awaitingSolve;
        private bool saved = false;
        private IViewInterface view;
        //TODO - make variable
        const long inspectionTime = 3; // in s
        List<Statistics> statistics = new List<Statistics>();

        public Controller(IViewInterface view)
        {
            this.view = view;
            state = State.WAIT;
            view.DNF = " ";
            currentCubeType = CubeType.THREE;
            tempSolve = GenerateSolve();
            view.Scramble = tempSolve.Scramble;

            view.CubeTypeLabelInter = ($"{CubeTypeToLabel(currentCubeType)}");

            //load from text file
            // TODO - strategy? statistics multiple instatances
            statistics.Add(new Statistics(CubeType.TWO));
            statistics.Add(new Statistics(CubeType.THREE));
            statistics.Add(new Statistics(CubeType.FOUR));
            GetStatistics(currentCubeType).InitializeViewStatistics(view,15);
        }

        private Statistics GetStatistics(CubeType cubetype)
        {
            switch (cubetype)
            {
                case CubeType.TWO:
                    return statistics[0];
                    break;
                case CubeType.THREE:
                    return statistics[1];
                    break;
                case CubeType.FOUR:
                    return statistics[2];
                    break;
                default:
                    throw new InvalidOperationException("Invalid cube type");
                    break;
            }
        }
        // keep as general as possible (controller pattern)
        public void startStopTimer()
        {
            switch (state)
            {
                // TODO - clear up the logic here
                case State.WAIT:
                    TimerClass.Instance.Reset();
                    TimerClass.Instance.Enable();
                    view.SetClockColor(Color.Green);
                    view.DNF = "";
                    // TODO - color dialog - user picked background
                    view.SetBackgroundColor(Color.FromArgb(30,30,30));
                    //TODO - db connection
                    //TODO - text connection
                    //TODO - save in background / edit last element (delete/add)
                    if(awaitingSolve != null && !saved) // don't save first solve
                    {
                        saved = true;
                        SaveSolve(awaitingSolve);
                        //TODO - current/ prev logic planning
                        GetStatistics(awaitingSolve.TypeOfCube).AddStatistics(view,15,awaitingSolve);
                    }
                    GetStatistics(currentCubeType).InitializeViewStatistics(view, 15);
                    state = State.INSPECT;
                    break;
                case State.INSPECT:
                    TimerClass.Instance.Reset();
                    TimerClass.Instance.Enable();
                    view.SetClockColor(Color.Red);
                    state = State.SOLVE;
                    break;
                case State.SOLVE:
                    tempSolve.SolveTime = (long)GetTime().TotalMilliseconds;
                    state = State.WAIT;
                    TimerClass.Instance.Disable();
                    saved = false;
                    awaitingSolve = tempSolve;
                    tempSolve = GenerateSolve();
                    view.Scramble = tempSolve.Scramble;
                    view.SetClockColor(Color.White);
                    view.SetBackgroundColor(Color.Black);
                    break;
                default:
                    throw new Exception("wrong state");
                    break;
            }
        }
        public void Update()
        {
            TimerClass.Instance.Tick();
            TimeSpan currentTime = GetTime();
            
            if(state == State.INSPECT)
            {
                if(currentTime.TotalSeconds > inspectionTime)
                {
                    state = State.WAIT;
                    view.SetClockColor(Color.White);
                    view.SetBackgroundColor(Color.Black);
                    tempSolve.IsDNF = true;
                    view.DNF = "DNF";
                    tempSolve.SolveTime = 0;
                    TimerClass.Instance.Reset();
                }
            }
            // TODO check if inspection is over
            view.ClockTime = currentTime.ToString(@"hh\:mm\:ss\:ff");
            
        }

        static private void SaveSolve(Solve solve)
        {
            foreach(DataConnection.IDataConnect c in GlobalConfig.ConnectionsList)
            {
                c.SaveSolveToDB(solve);
            }
        }
        static private string CubeTypeToLabel(CubeType cubetype)
        {
            switch (cubetype)
            {
                case CubeType.TWO:
                    return "2x2";
                    break;
                case CubeType.THREE:
                    return "3x3";
                    break;
                case CubeType.FOUR:
                    return "4x4";
                    break;
                default:
                    throw new InvalidOperationException("Unknown cube type");
                    break;
            }
        }
        public void SaveQueued()
        {
            //TODO - add queue
            if(awaitingSolve != null)
            {
                SaveSolve(awaitingSolve);
            }
        }
        public Solve GenerateSolve()
        {
            return new Solve(currentCubeType);
        }
        public string GetScramble()
        {
            return tempSolve.Scramble;
        }
        public TimeSpan GetTime()
        {
            return TimerClass.Instance.GetTime();
        }
        public void ChangeCubeType(CubeType newCubeType)
        {
            currentCubeType = newCubeType;
            state = State.WAIT;
            view.SetClockColor(Color.White);
            view.SetBackgroundColor(Color.Black);
            TimerClass.Instance.Reset();
            tempSolve = GenerateSolve();
            view.Scramble = tempSolve.Scramble;
            view.CubeTypeLabelInter = CubeTypeToLabel(newCubeType);
            GetStatistics(newCubeType).InitializeViewStatistics(view, 15);
        }
        public bool isSolving()
        {
            return (state == State.SOLVE);
        }
        public bool isInspecting()
        {
            return (state == State.INSPECT);
        }
        public bool isWating()
        {
            return (state == State.WAIT);
        }
    }
}
