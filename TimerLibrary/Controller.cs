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
        //TODO - make variable
        const long inspectionTime = 15000; // in ms

        public Controller()
        {
            state = State.WAIT;
            // TODO - other cubes compatibility
            tempSolve = new Solve(CubeType.THREE);
        }
        // tak ogólne jak można
        public void startStopTimer()
        {
            switch (state)
            {
                case State.WAIT:
                    TimerClass.Instance.Reset();
                    //TODO - other cubes
                    tempSolve = new Solve(CubeType.THREE);
                    //TODO - db connection
                    state = State.INSPECT;
                    break;
                case State.INSPECT:
                    TimerClass.Instance.Reset();
                    state = State.SOLVE;
                    break;
                case State.SOLVE:
                    state = State.WAIT;
                    tempSolve.SolveTime = GetTime();
                    break;
                default:
                    break;
            }
        }

        public void Update()
        {
            if(state == State.INSPECT)
            {
                if(GetTime() > inspectionTime)
                {
                    state = State.WAIT;
                    tempSolve.IsDNF = true;
                    tempSolve.SolveTime = 0;
                }
            }
            // TODO check if inspect over
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
        public long GetTime()
        {
            return TimerClass.Instance.GetTime();
        }
    }
}
