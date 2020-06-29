using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
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
        public Solve tempSolve;
        //TODO - solves awaiting for save (queue?)
        private Solve awaitingSolve;
        private IViewInterface view; 
        //TODO - make variable
        const long inspectionTime = 3; // in s

        public Controller(IViewInterface view)
        {
            this.view = view;
            state = State.WAIT;
            tempSolve = new Solve(CubeType.THREE);
            view.Scramble = tempSolve.Scramble;
            view.DNF = tempSolve.IsDNF ? "DNF" : " ";
        }
        // keep as general as possible (controller pattern)
        public void startStopTimer()
        {
            switch (state)
            {
                case State.WAIT:
                    TimerClass.Instance.Reset();
                    TimerClass.Instance.Enable();
                    //TODO - db connection
                    //TODO - text connection
                    state = State.INSPECT;
                    break;
                case State.INSPECT:
                    TimerClass.Instance.Reset();
                    TimerClass.Instance.Enable();
                    state = State.SOLVE;
                    break;
                case State.SOLVE:
                    TimerClass.Instance.Disable();
                    state = State.WAIT;
                    tempSolve.SolveTime = (long)GetTime().TotalMilliseconds;
                    //TODO - other cubes
                    awaitingSolve = tempSolve;
                    tempSolve = new Solve(CubeType.THREE);
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
                    tempSolve.IsDNF = true;
                    tempSolve.SolveTime = 0;
                }
            }
            // TODO check if inspection is over
            view.ClockTime = currentTime.ToString(@"hh\:mm\:ss\:ff");
            view.DNF = tempSolve.IsDNF ? "DNF" : " ";
        }

        public void generateSolve()
        {
            // TODO new cubeTypes
            tempSolve = new Solve(CubeType.THREE);
        }
        public string GetScramble()
        {
            return tempSolve.Scramble;
        }
        public TimeSpan GetTime()
        {
            return TimerClass.Instance.GetTime();
        }
    }
}
