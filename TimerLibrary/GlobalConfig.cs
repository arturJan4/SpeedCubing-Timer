using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLibrary.DataConnection;

namespace TimerLibrary
{
    /// <summary>
    /// Class linking connections to respective databases
    /// </summary>
    public static class GlobalConfig
    {
        public static List<IDataConnect> ConnectionsList { get; set; } = new List<IDataConnect>();

        public static void Initialize(bool dbOpen, bool textFileOpen)
        {
            if (dbOpen)
            {

                //TODO - implement DB connection
            }

            if (textFileOpen)
            {
                //TODO - implement text file connection
                TextConnect text = new TextConnect();
                ConnectionsList.Add(text);
            }
        }
    }
}
