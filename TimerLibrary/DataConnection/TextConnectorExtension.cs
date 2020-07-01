using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TimerLibrary.DataConnection.Extensions
{
    /// <summary>
    /// Extension of TextConnect class in seperate file and namespace 
    /// to allow linking methods
    /// </summary>
    public static class TextConnectorExtension
    {
        // TODO - extension method
        // TODO - comment
        public static string FilePath(this string filepath)
        {
            //TODO - App.config link
            //return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ filepath }";
            return $"{ filepath }";
        }
        public static string OverrideFile(this string filepath)
        {
            File.WriteAllText(filepath, String.Empty);
            return filepath;
        }
        public static List<string> LoadFile(this string filepath)
        {
            if (!File.Exists(filepath))
            {
                return new List<string>();
            }

            return File.ReadAllLines(filepath).ToList();
        }
        public static List<Solve> ConvertToSolves(this List<string> lines)
        {
            List<Solve> outList = new List<Solve>();
            foreach (string l in lines)
            {
                string[] cols = l.Split(',');
                Solve sol = new Solve();
                // TODO - make new load from file constructor instead?
                try
                {
                    sol.Id = int.Parse(cols[0]);
                    sol.SolveTime = long.Parse(cols[1]);
                    sol.Scramble = cols[2];
                    sol.IsDNF = bool.Parse(cols[3]);
                    sol.TypeOfCube = (CubeType)Enum.Parse(typeof(CubeType), cols[4]);
                    outList.Add(sol);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Parsing from text file - error {e}");
                }
            }
            return outList;
        }
        public static void SaveToSolveFile(this List<Solve> solves, string filepath)
        {
            List<string> lines = new List<string>();
            foreach(Solve s in solves)
            {
                lines.Add($"{s.Id},{s.SolveTime},{s.Scramble},{s.IsDNF},{s.TypeOfCube}");
            }

            File.WriteAllLines(filepath.FilePath(), lines);
        }
    }
}
