using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// Deletes all stats from database.
        /// </summary>
        /// <returns>Should return empty list</returns>
        public List<Solve> DeleteAll()
        {
            return SolvesFile.FilePath().OverrideFile().LoadFile().ConvertToSolves();
        }
        /// <summary>
        /// Deletes a statistics with a given id.
        /// </summary>
        /// <param name="id">unique id</param>
        /// <returns>List without Solve with given id.</returns>
        public List<Solve> DeleteById(int id)
        {
            List<Solve> solves = LoadSolvesFromDB();
            solves.RemoveAll(x => (x.Id == id));
            DeleteAll();
            SaveSolveListToDb(solves);
            return solves;
        }
        /// <summary>
        /// Deletes last element in the database.
        /// </summary>
        /// <returns></returns>
        public Solve DeleteLast()
        {
            List<Solve> solves = LoadSolvesFromDB();
            if (solves.Count >= 1)
            {
                solves.RemoveAt(solves.Count - 1);
            }
            DeleteAll();
            SaveSolveListToDb(solves);
            if (solves.Count >= 1)
            {
                return solves[solves.Count - 1];
            }
            return null;
        }
        /// <summary>
        /// Loads all solves to a list of solves from the database.
        /// </summary>
        /// <returns>List of solves in the database</returns>
        public List<Solve> LoadSolvesFromDB()
        {
            return SolvesFile.FilePath().LoadFile().ConvertToSolves();
        }
        /// <summary>
        /// Saves a list of solves to the database.
        /// </summary>
        /// <param name="solveList"></param>
        /// <returns></returns>
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

            foreach (Solve s in solveList)
            {
                s.Id = currId;
                currId++;
                solves.Add(s);
            }
            solves.SaveToSolveFile(SolvesFile);
            return solves;
        }
        /// <summary>
        /// Saves one solve to the database (without overriding anything!)
        /// </summary>
        /// <param name="solve"></param>
        /// <returns>Saved solve with correctly set ID</returns>
        public Solve SaveSolveToDB(Solve solve)
        {
            // load to List<Solve> from file
            List<Solve> solves = LoadSolvesFromDB();

            // find the ID
            int currId = 1;
            if (solves.Count > 0)
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
