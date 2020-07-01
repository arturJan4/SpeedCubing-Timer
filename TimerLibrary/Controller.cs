﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
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
        const int HowManyRowsVisible = 200;
        public int InspectionTime { get; set; } = 15;// in s

        public string DirName;
        public Sound SoundControl;
        int BeepNumber;

        public Solve tempSolve;
        private Solve awaitingSolve;
        static List<Statistics> statistics = new List<Statistics> { new Statistics(CubeType.TWO) , new Statistics(CubeType.THREE), new Statistics(CubeType.FOUR)};

        private State state;
        private CubeType currentCubeType;
        private IViewInterface view;
        public Controller(IViewInterface view)
        {
            this.view = view;
            state = State.WAIT;
            view.DNF = " ";
            currentCubeType = CubeType.THREE;
            tempSolve = GenerateSolve();
            view.Scramble = tempSolve.Scramble;

            SoundControl = new Sound(DirName);
            SoundControl.PlaySounds = true;

            view.CubeTypeLabelInter = ($"{CubeTypeToLabel(currentCubeType)}");

            //load from text file
            UpdateStatistics();
        }

        // keep as general as possible (controller pattern)
        #region MainStateMachine
        public void startStopTimer()
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
                    UpdateStatistics();

                    awaitingSolve = tempSolve;                 
                    tempSolve = GenerateSolve();                             //generate new solve
                    break;
                default:
                    throw new Exception("wrong state");
                    break;
            }
            UIStateChanges();
            state = GetNextState(state);
        }
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
        public void Update()
        {
            TimerClass.Instance.Tick();
            TimeSpan currentTime = GetTime();
            
            if(state == State.INSPECT)
            {
                double percentageEnd = currentTime.TotalSeconds / InspectionTime;
                int colorShift = (int)Math.Floor(percentageEnd * 250);
                int red = colorShift;
                int green = 255 - colorShift;
                view.SetClockColor(Color.FromArgb(red, green, 0));

                if((BeepNumber == 0 && percentageEnd > 0.5) ||
                   (BeepNumber == 1 && percentageEnd > 0.75)||
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
        static private void SaveSolve(Solve solve)
        {
            foreach(DataConnection.IDataConnect c in GlobalConfig.ConnectionsList)
            {
                c.SaveSolveToDB(solve);
            }

        }
        static private void SaveSolveList(List<Solve> solveList)
        {
            foreach (DataConnection.IDataConnect c in GlobalConfig.ConnectionsList)
            {
                c.SaveSolveListToDb(solveList);
            }
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
            GetStatistics(newCubeType).InitializeViewStatistics(view, HowManyRowsVisible);
        }
        public void ChangePlaySounds()
        {
            SoundControl.PlaySounds = !SoundControl.PlaySounds;
        }
        public void SetDNF()
        {
            if(state == State.WAIT && awaitingSolve != null)
            {
                awaitingSolve.IsDNF = true;
                
                view.DNF = "DNF";
                DeleteAllStatistics();
                List<Solve> newList = GetStatistics(awaitingSolve.TypeOfCube).GetSolvesList();
                newList.RemoveAt(newList.Count - 1);
                newList.Add(awaitingSolve);

                SaveSolveList(newList);
                UpdateStatistics();
            }

        }
        public void DeleteAllStatistics()
        {
            foreach (DataConnection.IDataConnect c in GlobalConfig.ConnectionsList)
            {
                c.DeleteAll();
            }
            GetStatistics(currentCubeType).InitializeViewStatistics(view, HowManyRowsVisible);
        }
        public void DeleteStatisticsById(int id)
        {
            foreach (DataConnection.IDataConnect c in GlobalConfig.ConnectionsList)
            {
                c.DeleteById(id);
            }
            GetStatistics(currentCubeType).InitializeViewStatistics(view, HowManyRowsVisible);

        }
        public void DeleteLast()
        {
            foreach (DataConnection.IDataConnect c in GlobalConfig.ConnectionsList)
            {
                c.DeleteLast();
            }
            GetStatistics(currentCubeType).InitializeViewStatistics(view, HowManyRowsVisible);

        }
        public void UpdateStatistics()
        {
            GetStatistics(currentCubeType).InitializeViewStatistics(view, HowManyRowsVisible);
            view.GoToLastStatistics();
        }

        #endregion
        #region Getters
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
