using System;
using TimerLibrary.Scrambles;

namespace TimerLibrary
{
    public class Solve
    {
        /// <summary>
        /// Unique id as a key for database saving/loading.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Time of solve in miliseconds (1/1000 of a second).
        /// </summary>
        public long SolveTime { get; set; }
        /// <summary>
        /// String Representation of a generated random scramble.
        /// </summary>
        public string Scramble { get; set; }
        /// <summary>
        /// DNF occurs when the inspection timer wasn't stopped by the user (dealt by internal logic)
        /// or when the cube isn't solved completely when user stopped the timer (dealt by user input).
        /// </summary>
        public bool IsDNF { get; set; }
        /// <summary>
        /// For example 3x3, 4x4, Pyraminx, Skewb.
        /// </summary>
        public CubeType TypeOfCube { get; set; }
        /// <summary>
        /// Empty Constructor only for recreating Solves from database files.
        /// </summary>
        public Solve()
        {

        }
        /// <summary>
        /// Default Constructor automatically creating a random scramble of given cubeType.
        /// </summary>
        /// <param name="cubeType">Enum Type (TWO|THREE|FOUR), meaning 2x2, 3x3, 4x4 cubes.</param>
        public Solve(CubeType cubeType)
        {
            Scramble = (new Scramble(CubeTypeToStrategy(cubeType))).Representation;
            SolveTime = 0;
            IsDNF = false;
            TypeOfCube = cubeType;
        }
        /// <summary>
        /// Returns a scrambling strategy give a type of cube
        /// </summary>
        /// <param name="cubeType">Type of cube (example 3x3, 2x2)</param>
        /// <returns>Scrambling strategy</returns>
        private static IGenerateScrambleInterface CubeTypeToStrategy(CubeType cubeType)
        {
            IGenerateScrambleInterface strategy;
            switch (cubeType)
            {
                case CubeType.TWO:
                    strategy = new TwoByTwoScramble();
                    break;
                case CubeType.THREE:
                    strategy = new ThreeByThreeScramble();
                    break;
                case CubeType.FOUR:
                    strategy = new FourByFourScramble();
                    break;
                default:
                    throw new InvalidOperationException("Unknown cube type");
                    break;
            }
            return strategy;
        }
    }
}
