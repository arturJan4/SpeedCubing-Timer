using System.Collections.Generic;

namespace TimerLibrary.DataConnection
{
    /// <summary>
    /// DB operations interface.
    /// </summary>
    public interface IDataConnect
    {
        /// <summary>
        /// Appends a list of solves to the current database.
        /// </summary>
        /// <param name="solveList"></param>
        /// <returns></returns>
        List<Solve> SaveSolveListToDb(List<Solve> solveList);
        /// <summary>
        /// Appends a solve to the current database.
        /// </summary>
        /// <param name="solve"></param>
        /// <returns></returns>
        Solve SaveSolveToDB(Solve solve);
        /// <summary>
        /// Returns a List of solves from a database.
        /// </summary>
        /// <returns>List of solves from a database</returns>
        List<Solve> LoadSolvesFromDB();
        /// <summary>
        /// Deletes an item of specific unique id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Solve> DeleteById(int id);
        /// <summary>
        /// Deletes element at last id
        /// </summary>
        /// <returns></returns>
        Solve DeleteLast();
        /// <summary>
        /// Deletes all element from a database.
        /// </summary>
        /// <returns></returns>
        List<Solve> DeleteAll();
    }
}
