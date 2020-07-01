using System.Collections.Generic;
using TimerLibrary.DataConnection;

namespace TimerLibrary
{
    /// <summary>
    /// Class linking connections to respective databases
    /// </summary>
    public static class GlobalConfig
    {
        /// <summary>
        /// List of connected databases
        /// </summary>
        public static List<IDataConnect> ConnectionsList { get; set; } = new List<IDataConnect>();
        public static void Initialize(bool dbOpen, bool textFileOpen)
        {
            if (dbOpen)
            {
                //TODO - implement DB connection
            }

            if (textFileOpen)
            {
                TextConnect text = new TextConnect();
                ConnectionsList.Add(text);
            }
        }
    }
}
