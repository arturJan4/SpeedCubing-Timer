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
        private IViewInterface view; 
        //TODO - make variable
        const long inspectionTime = 15000; // in ms

        public Controller(IViewInterface view)
        {
            this.view = view;
            state = State.WAIT;
        }
        // tak ogólne jak można
        public void startStopTimer()
        {
            switch (state)
            {
                case State.WAIT:
                    TimerClass.Instance.Reset();
                    TimerClass.Instance.Enable();
                    //TODO - other cubes
                    tempSolve = new Solve(CubeType.THREE);
                    //TODO - db connection
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
            // TODO check if inspect over
            view.ClockTime = currentTime.ToString(@"hh\:mm\:ss\:ff");
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
