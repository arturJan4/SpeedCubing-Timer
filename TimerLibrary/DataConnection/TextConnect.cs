using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLibrary.DataConnection.Extensions;

namespace TimerLibrary.DataConnection
{
    /// <summary>
    /// Implements a text database operations.
    /// </summary>
    public class TextConnect : IDataConnect
    {
        // inspired partly by Tim Corey's tutorial: https://www.youtube.com/watch?v=X_P70uukPrU
        private const string SolvesFile = "Solves.csv";

        public List<Solve> DeleteAll()
        {
            return SolvesFile.FilePath().OverrideFile().LoadFile().ConvertToSolves();
        }
        public List<Solve> DeleteById(int id)
        {
            List<Solve> solves = LoadSolvesFromDB();
            solves.RemoveAll(x => (x.Id == id));
            DeleteAll();
            SaveSolveListToDb(solves);
            return solves;
        }
        public Solve DeleteLast()
        {
            List<Solve> solves = LoadSolvesFromDB();
            if(solves.Any())
            {
                solves.RemoveAt(solves.Count - 1);
            }
            DeleteAll();
            SaveSolveListToDb(solves);
            if(solves.Any())
            {
                return solves[solves.Count - 1];
            }
            return null;
        }
        public List<Solve> LoadSolvesFromDB()
        {
            return SolvesFile.FilePath().LoadFile().ConvertToSolves();
        }
        public List<Solve> SaveSolveListToDb(List<Solve> solveList)
        {
            // load to List<Solve> from file
            List<Solve> solves = LoadSolvesFromDB();

            // find the ID
            int currId = 1;
            if (solves.Count > 0)
            {
                currId = solves.OrderByDescending(x => x.Id).First().Id + 1;
            }

            foreach(Solve s in solveList)
            {
                s.Id = currId;
                currId++;
                solves.Add(s);
            }
            solves.SaveToSolveFile(SolvesFile);
            return solves;
        }

        // TODO - change App.config so that it works on local files independent of the user
        public Solve SaveSolveToDB(Solve solve)
        {
            // load to List<Solve> from file
            List<Solve> solves = LoadSolvesFromDB();

            // find the ID
            int currId = 1;
            if(solves.Count > 0)
            {
                currId = solves.OrderByDescending(x => x.Id).First().Id + 1;
            }
            solve.Id = currId;
            // add new record
            solves.Add(solve);

            // convert to list<string>
            // save to file
            solves.SaveToSolveFile(SolvesFile);

            return solve;
        }
    }
}
