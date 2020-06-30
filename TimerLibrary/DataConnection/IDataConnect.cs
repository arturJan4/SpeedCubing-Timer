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
        Solve SaveSolveToDB(Solve solve);
        List<Solve> LoadSolvesFromDB();
    }
}
