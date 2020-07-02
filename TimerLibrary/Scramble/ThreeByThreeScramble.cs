using System.Collections.Generic;

namespace TimerLibrary.Scrambles
{
    /// <summary>
    /// Generates a random 3x3 scramble, 
    /// non-repeating sequence of moves, separated with spaces,
    /// </summary>
    public class ThreeByThreeScramble : IGenerateScrambleInterface
    {
        // TODO - check for more stuff (ex. whether user can solve in less than 3 moves).
        /// <summary>
        /// Generates a random 3x3 scramble, 
        /// non-repeating sequence of moves, separated with spaces,
        /// </summary>
        /// <returns></returns>
        public List<Move> GenerateScramble()
        {
            const int moveNumber = 20; //official WCA regulations
            const int rowsAtOnce = 1;
            List<Move> moveList = new List<Move>(moveNumber);

            int i = moveNumber;
            Move prevMove = Move.GetRandomMove(rowsAtOnce);
            moveList.Add(prevMove);
            --i;
            while (i != 0)
            {
                Move nextMove = Move.GetRandomMove(rowsAtOnce);
                if (nextMove.ToStringRepresentation() != prevMove.ToStringRepresentation())
                {
                    moveList.Add(nextMove);
                    prevMove = nextMove;
                    i--;
                }
            }
            return moveList;
        }
    }
}
