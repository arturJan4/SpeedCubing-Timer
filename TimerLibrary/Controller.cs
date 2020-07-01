using System;
using System.Collections.Generic;
using System.Drawing;

namespace TimerLibrary
{
    /// <summary>
    /// Main Controller class, arbitrates communication between
    /// Views and Models
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// Current State of controller state machine.
        /// </summary>
        public enum State
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
        public int InspectionTime { get; set; } = 15; // Inspection Time in seconds

        public string DirName;              // Path to .exe directory
        public Sound SoundControl;
        int BeepNumber;                     //which beep is it (for inspection urging user to start)

        public Solve tempSolve;             //currently processed solve
        private Solve awaitingSolve;        //previous solve (for changing last solve when user selects DNF)
        static readonly List<Statistics> statistics = new List<Statistics> { new Statistics(CubeType.TWO), new Statistics(CubeType.THREE), new Statistics(CubeType.FOUR) };

        const int HowManyRowsVisible = 200; // How many rows should be visible in a Statistics box at once

        private State state;
        private CubeType currentCubeType;
        private readonly IViewInterface view;        // view interface between controller and form
        public Controller(IViewInterface view)
        {
            this.view = view;                   // bind view
            state = State.WAIT;                 // defualt state
            currentCubeType = CubeType.THREE;   // default cube
            view.DNF = " ";                     // not DNF
            tempSolve = GenerateSolve();
            view.Scramble = tempSolve.Scramble;

            SoundControl = new Sound(DirName)
            {
                PlaySounds = true     // defualt - play sounds
            };

            view.CubeTypeLabelInter = ($"{CubeTypeToLabel(currentCubeType)}");

            UpdateStatistics();                  // load from text file and update
        }

        #region MainStateMachine
        /// <summary>
        /// Takes proper action depending on current state.
        /// Activated when user interacts with the timer (either by button or keyboard).
        /// </summary>
        public void StartStopTimer()
        {
            switch (state)
            {
                case State.WAIT:
                    TimerClass.Instance.Reset();
                    TimerClass.Instance.Enable();
                    break;
                case State.INSPECT:
                    TimerClass.Instance.Reset();
                    TimerClass.Instance.Enable();
                    break;
                case State.SOLVE:
                    tempSolve.SolveTime = (long)GetTime().TotalMilliseconds; //get time
                    TimerClass.Instance.Disable();

                    SaveSolve(tempSolve);                                    //save solve
                    UpdateStatistics();                                      //updates new stats

                    awaitingSolve = tempSolve;                               //remembers the current solve before replacing it
                    tempSolve = GenerateSolve();                             //generate new solve
                    break;
                default:
                    throw new Exception("wrong state");
                    break;
            }
            UIStateChanges();
            state = GetNextState(state);
        }
        /// <summary>
        /// Updates UI and plays sound based on current state
        /// </summary>
        public void UIStateChanges()
        {
            switch (state)
            {
                case State.WAIT:
                    SoundControl.PlayInspectionStartSound();
                    view.SetBackgroundColor(Color.FromArgb(30, 30, 30));
                    view.SetClockColor(Color.Green);
                    view.DNF = "";
                    break;
                case State.INSPECT:
                    view.SetClockColor(Color.Red);
                    break;
                case State.SOLVE:
                    SoundControl.PlaySolveEndSound();
                    view.Scramble = tempSolve.Scramble;
                    view.SetClockColor(Color.White);
                    view.SetBackgroundColor(Color.Black);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Updates timer Label and checks for inspection triggers.
        /// Uses form internal timer (which updates not so often as one from the Timer class)
        /// </summary>
        public void Update()
        {
            TimeSpan currentTime = GetTime();

            if (state == State.INSPECT)
            {
                double percentageEnd = currentTime.TotalSeconds / InspectionTime;
                int colorShift = (int)Math.Floor(percentageEnd * 250);
                int red = colorShift;
                int green = 255 - colorShift;
                view.SetClockColor(Color.FromArgb(red, green, 0));

                if ((BeepNumber == 0 && percentageEnd > 0.5) ||
                   (BeepNumber == 1 && percentageEnd > 0.75) ||
                   (BeepNumber == 2 && percentageEnd > 0.9) ||
                   (BeepNumber == 3 && percentageEnd > 0.95))
                {
                    SoundControl.PlayInspectionEndSound();
                    BeepNumber++;
                }

                if (currentTime.TotalSeconds > InspectionTime)
                {
                    state = State.WAIT;
                    view.SetClockColor(Color.White);
                    view.SetBackgroundColor(Color.Black);
                    tempSolve.IsDNF = true;
                    view.DNF = "DNF";
                    tempSolve.SolveTime = 0;
                    TimerClass.Instance.Reset();
                    BeepNumber = 0;
                }
            }
            view.ClockTime = currentTime.ToString(@"hh\:mm\:ss\:ff");
        }
        /// <summary>
        /// Gets the next state
        /// </summary>
        /// <param name="state">Current state</param>
        /// <returns></returns>
        private static State GetNextState(State state)
        {
            switch (state)
            {
                case State.WAIT:
                    return State.INSPECT;
                    break;
                case State.INSPECT:
                    return State.SOLVE;
                    break;
                case State.SOLVE:
                    return State.WAIT;
                    break;
                default:
                    throw new InvalidOperationException("Unknown state");
                    break;
            }
        }
        #endregion
        #region Setters
        /// <summary>
        /// Saves solve to all databases.
        /// </summary>
        /// <param name="solve"></param>
        static private void SaveSolve(Solve solve)
        {
            foreach (DataConnection.IDataConnect c in GlobalConfig.ConnectionsList)
            {
                c.SaveSolveToDB(solve);
            }
        }
        /// <summary>
        /// Saves a list of solves to all databases.
        /// </summary>
        /// <param name="solveList"></param>
        static private void SaveSolveList(List<Solve> solveList)
        {
            foreach (DataConnection.IDataConnect c in GlobalConfig.ConnectionsList)
            {
                c.SaveSolveListToDb(solveList);
            }
        }
        /// <summary>
        /// Changes current cube type.
        /// </summary>
        /// <param name="newCubeType">New cube type to be set</param>
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
            GetStatistics(newCubeType).InitializeViewStatistics(view, HowManyRowsVisible);
        }
        /// <summary>
        /// Turns on/off sound playing.
        /// </summary>
        public void ChangePlaySounds()
        {
            SoundControl.PlaySounds = !SoundControl.PlaySounds;
        }
        /// <summary>
        /// If possible changes past solve to DNF and deletes it from visible list box.
        /// </summary>
        public void SetDNF()
        {
            if (state == State.WAIT && awaitingSolve != null)
            {
                awaitingSolve.IsDNF = true;

                view.DNF = "DNF";
                DeleteAllStatistics();
                List<Solve> newList = GetStatistics(awaitingSolve.TypeOfCube).GetSolvesList();
                if (newList.Count >= 1)
                {
                    newList.RemoveAt(newList.Count - 1);
                    newList.Add(awaitingSolve);
                }

                SaveSolveList(newList);
                UpdateStatistics();
            }

        }
        /// <summary>
        /// Deletes ALL!(independent of cube type) statistics from all databases.
        /// </summary>
        public void DeleteAllStatistics()
        {
            foreach (DataConnection.IDataConnect c in GlobalConfig.ConnectionsList)
            {
                c.DeleteAll();
            }
            GetStatistics(currentCubeType).InitializeViewStatistics(view, HowManyRowsVisible);
        }
        /// <summary>
        /// Deletes a cube specified by ID from all databases.
        /// </summary>
        /// <param name="id">Unqique positive id - key in database</param>
        public void DeleteStatisticsById(int id)
        {
            foreach (DataConnection.IDataConnect c in GlobalConfig.ConnectionsList)
            {
                c.DeleteById(id);
            }
            GetStatistics(currentCubeType).InitializeViewStatistics(view, HowManyRowsVisible);
        }
        /// <summary>
        /// Deletes last added solve from all databases.
        /// </summary>
        public void DeleteLast()
        {
            foreach (DataConnection.IDataConnect c in GlobalConfig.ConnectionsList)
            {
                c.DeleteLast();
            }
            GetStatistics(currentCubeType).InitializeViewStatistics(view, HowManyRowsVisible);

        }
        /// <summary>
        /// Updates all statistics and labels, displays them, and scroll to the bottom of listbox.
        /// </summary>
        public void UpdateStatistics()
        {
            GetStatistics(currentCubeType).InitializeViewStatistics(view, HowManyRowsVisible);
            view.GoToLastStatistics();
        }

        #endregion
        #region Getters
        public bool IsSolving()
        {
            return (state == State.SOLVE);
        }
        public bool IsInspecting()
        {
            return (state == State.INSPECT);
        }
        public bool IsWating()
        {
            return (state == State.WAIT);
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
        static private Statistics GetStatistics(CubeType cubetype)
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
        #endregion
    }
}
