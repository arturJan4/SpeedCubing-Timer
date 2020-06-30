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

        public Controller(IViewInterface view)
        {
            this.view = view;
            state = State.WAIT;
            tempSolve = new Solve(CubeType.THREE);
            view.Scramble = tempSolve.Scramble;
            view.DNF = " ";
            currentCubeType = CubeType.THREE;
            //load from text file
            Statistics.Initialize();
            Statistics.InitializeViewStatistics(view, 15);
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
                    view.SetBackgroundColor(Color.DarkGray);
                    //TODO - db connection
                    //TODO - text connection
                    //TODO - save in background / edit last element (delete/add)
                    if(awaitingSolve != null && !saved) // don't save first solve
                    {
                        saved = true;
                        SaveSolve(awaitingSolve);
                        Statistics.AddStatistics(view,15,awaitingSolve);
                    }
                    
                    state = State.INSPECT;
                    break;
                case State.INSPECT:
                    TimerClass.Instance.Reset();
                    TimerClass.Instance.Enable();
                    view.SetClockColor(Color.Red);
                    state = State.SOLVE;
                    break;
                case State.SOLVE:
                    TimerClass.Instance.Disable();
                    view.SetClockColor(Color.White);
                    view.SetBackgroundColor(Color.Black);
                    state = State.WAIT;
                    tempSolve.SolveTime = (long)GetTime().TotalMilliseconds;
                    //TODO - other cubes
                    saved = false;
                    awaitingSolve = tempSolve;
                    tempSolve = GenerateSolve();
                    view.Scramble = tempSolve.Scramble;
                    break;
                default:
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
            // TODO new cubeTypes
            return new Solve(CubeType.THREE);
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
