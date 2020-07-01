using System;
using System.Text;

namespace TimerLibrary
{
    /// <summary>
    /// Represents one turn of a rubik's cube.
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Represent which side you have to turn.
        /// </summary>
        /// <example> F - front side turn, U - upper </example>
        public MoveType TypeOfMove { get; }
        /// <summary>
        /// How many rows at once do you have to turn.
        /// </summary>
        /// <example> for 2x2 and 3x3 - max is 1, but for 4x4 you can turn two rows at once</example>
        public uint RowsAtOnce { get; }
        /// <summary>
        /// True if move is double (with suffix -2), meaning by 180 degrees.
        /// </summary>
        public bool IsDouble { get; }
        /// <summary>
        /// True if move is in anticlockwise direction.
        /// </summary>
        public bool IsAnticlockwise { get; }
        /// <summary>
        /// Generates a randomMove with random parameters.
        /// </summary>
        /// <param name="rowsAtOnce"> How many rows at once can you turn in a given cube.</param>
        /// <returns></returns>
        public static Move GetRandomMove(uint rowsAtOnce)
        {
            if (rowsAtOnce == 0)
            {
                throw new ArgumentOutOfRangeException("RowsAtOnce has to be positive");
            }

            Random rand = new Random();
            Array possibleMoves = Enum.GetValues(typeof(MoveType));

            MoveType type = (MoveType)possibleMoves.GetValue(rand.Next(possibleMoves.Length));

            int modifierRand = rand.Next(0, 2);
            bool isDouble = (modifierRand == 1);
            bool isAnticlockwise = (modifierRand == 2);

            uint rowsAtOnceRandom = (uint)rand.Next(1, (int)rowsAtOnce);
            return new Move(type, rowsAtOnceRandom, isDouble, isAnticlockwise);
        }
        /// <summary>
        /// String representation of a move (as regulated by WCA).
        /// ex. R2 - right face by 180 degrees, 
        /// U' - Upper anticlockwise by 90 degrees
        /// </summary>
        /// <returns> String representing a move.</returns>
        public string ToStringRepresentation()
        {
            StringBuilder output = new StringBuilder();
            string enumName = Enum.GetName(typeof(MoveType), TypeOfMove);
            output.Append(enumName);

            if (IsDouble)
            {
                output.Append("2");
            }
            if (IsAnticlockwise)
            {
                output.Append("'");
            }
            if (RowsAtOnce > 1)
            {
                output.Append($"({RowsAtOnce})");
            }

            return output.ToString();
        }
        /// <summary>
        /// Constructor with all parameters.
        /// </summary>
        /// <param name="moveType">Enum type (F|R|L|U|D)</param>
        /// <param name="rowsAtOnce">How many rows at once can you turn (1 for 3x3, 2 for 4x4)</param>
        /// <param name="isDouble">The rotation is by 180 degrees</param>
        /// <param name="isAnticlockwise">The rotation is anticlockwise (prim ')</param>
        public Move(MoveType moveType, uint rowsAtOnce, bool isDouble, bool isAnticlockwise)
        {
            if (rowsAtOnce == 0)
            {
                throw new ArgumentOutOfRangeException("rowsAtOnce has to be positive");
            }

            if (isDouble && isAnticlockwise)
            {
                throw new ArgumentException("Move by 180 degrees has to be specified either clockwise or anticlockwise");
            }

            TypeOfMove = moveType;
            RowsAtOnce = rowsAtOnce;
            IsDouble = isDouble;
            IsAnticlockwise = isAnticlockwise;
        }
    }
}
