using System.Collections.Generic;
using System.Text;

namespace TimerLibrary.Scrambles
{
    /// <summary>
    /// Scramble class, generating sequence of
    /// moves, with variety depending on passed scrambling strategy
    /// </summary>
    public class Scramble
    {
        /// <summary>
        /// Allows dynamic choosing of a scrambling algorithm.
        /// </summary>
        private IGenerateScrambleInterface GenerateInterface;
        /// <summary>
        /// List of Moves generated from scrambling algorithm.
        /// </summary>
        public List<Move> Moves { get; }
        /// <summary>
        /// String representation of a scramble, moves seperated by spaces.
        /// Length depends on passed strategy.
        /// </summary>
        /// <example>
        /// for 3x3: R2 F U D U' L L2 R L' R U D F2 L D' U L2 R F' L
        /// </example>
        public string Representation { get; }
        /// <summary>
        /// Generates sequence of moves,
        /// variety depending on passed strategy.
        /// </summary>
        /// <param name="strategy">Scrambling algorithm (depenendant on cube type).</param>
        public Scramble(IGenerateScrambleInterface strategy)
        {
            GenerateInterface = strategy;
            Moves = strategy.GenerateScramble();

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Moves.Count; ++i)
            {
                if (i == Moves.Count - 1)
                {
                    builder.Append($"{Moves[i].ToStringRepresentation()}");
                }
                else
                {
                    builder.Append($"{Moves[i].ToStringRepresentation()} ");
                }
            }
            Representation = builder.ToString();
        }
    }
}
