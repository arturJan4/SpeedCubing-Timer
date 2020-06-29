using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    /// <summary>
    /// Represents one turn of a rubik's cube
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Represent which side you have to turn
        /// </summary>
        /// <example> F - front side turn, U - upper </example>
        public MoveType TypeOfMove { get; }
        /// <summary>
        /// How many rows at once do you have to turn
        /// </summary>
        /// <example> for 2x2 and 3x3 - max is 1, but for 4x4 you can turn two rows at once</example>
        public uint RowsAtOnce { get; }
        /// <summary>
        /// True if move is double (with suffix -2), meaning by 180 degrees
        /// </summary>
        public bool IsDouble { get; }
        /// <summary>
        /// True if move is in anticlockwise direction
        /// </summary>
        public bool IsAnticlockwise { get; }
        public static Move getRandomMove(uint rowsAtOnce)
        {
            if (rowsAtOnce == 0)
                throw new ArgumentOutOfRangeException("RowsAtOnce has to be positive");

            Random rand = new Random();
            Array possibleMoves = Enum.GetValues(typeof(MoveType));

            MoveType type = (MoveType)possibleMoves.GetValue(rand.Next(possibleMoves.Length));
            
            int modifierRand = rand.Next(0, 2);
            bool isDouble = (modifierRand == 1);
            bool isAnticlockwise = (modifierRand == 2);

            return new Move(type, rowsAtOnce, isDouble, isAnticlockwise);
        }
        // TODO - comment Move here
        public string ToStringRepresentation()
        {
            StringBuilder output = new StringBuilder();
            string enumName = Enum.GetName(typeof(MoveType), TypeOfMove);
            output.Append(enumName);
            
            if(IsDouble)
            {
                output.Append("2");
            }
            if(IsAnticlockwise)
            {
                output.Append("'");
            }
            if(RowsAtOnce > 1)
            {
                output.Append($"({RowsAtOnce})");
            }
            
            return output.ToString();
        }
        public Move(MoveType moveType, uint rowsAtOnce, bool isDouble, bool isAnticlockwise)
        {
            if (rowsAtOnce == 0)
                throw new ArgumentOutOfRangeException("rowsAtOnce has to be positive");
            if (isDouble && isAnticlockwise)
                throw new ArgumentException("Move by 180 degrees has to be specified either clockwise or anticlockwise");
            
            TypeOfMove = moveType;
            RowsAtOnce = rowsAtOnce;
            IsDouble = isDouble;
            IsAnticlockwise = isAnticlockwise;
        }
    }
}
