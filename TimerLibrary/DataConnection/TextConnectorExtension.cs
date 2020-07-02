using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TimerLibrary.DataConnection.Extensions
{
    /// <summary>
    /// Extension of TextConnect class in seperate file and namespace 
    /// to allow linking methods
    /// </summary>
    public static class TextConnectorExtension
    {
        /// <summary>
        /// Gets Full file path from app.config
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string FilePath(this string filepath)
        {
            //TODO - App.config link
            //return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ filepath }";
            return $"{ filepath }";
        }
        /// <summary>
        /// Overrided a file at a given filepath
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string OverrideFile(this string filepath)
        {
            File.WriteAllText(filepath, string.Empty);
            return filepath;
        }
        /// <summary>
        /// Loads a file
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>List of lines of a file</returns>
        public static List<string> LoadFile(this string filepath)
        {
            if (!File.Exists(filepath))
            {
                return new List<string>();
            }

            return File.ReadAllLines(filepath).ToList();
        }
        /// <summary>
        /// Converts from .csv format to a list of solves
        /// </summary>
        /// <param name="lines">lines of a program</param>
        /// <returns></returns>
        public static List<Solve> ConvertToSolves(this List<string> lines)
        {
            List<Solve> outList = new List<Solve>();
            foreach (string l in lines)
            {
                string[] cols = l.Split(',');
                Solve sol = new Solve();
                try
                {
                    sol.Id = int.Parse(cols[0]);
                    sol.SolveTime = long.Parse(cols[1]);
                    sol.Scramble = cols[2];
                    sol.IsDNF = bool.Parse(cols[3]);
                    sol.TypeOfCube = (CubeType)Enum.Parse(typeof(CubeType), cols[4]);
                    outList.Add(sol);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Parsing from text file - error {e}");
                }
            }
            return outList;
        }
        /// <summary>
        /// Saves a list of solves to  a file
        /// </summary>
        /// <param name="solves"></param>
        /// <param name="filepath"></param>
        public static void SaveToSolveFile(this List<Solve> solves, string filepath)
        {
            List<string> lines = new List<string>();
            foreach (Solve s in solves)
            {
                lines.Add($"{s.Id},{s.SolveTime},{s.Scramble},{s.IsDNF},{s.TypeOfCube}");
            }

            File.WriteAllLines(filepath.FilePath(), lines);
        }
    }
}
