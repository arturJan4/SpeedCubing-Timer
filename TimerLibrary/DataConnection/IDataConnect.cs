using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary.DataConnection
{
    /// <summary>
    /// DB operations interface.
    /// </summary>
    public interface IDataConnect
    {
        List<Solve> SaveSolveListToDb(List<Solve> solveList);
        Solve SaveSolveToDB(Solve solve);
        List<Solve> LoadSolvesFromDB();
        List<Solve> DeleteById(int id);
        Solve DeleteLast();
        List<Solve> DeleteAll();
    }
}
