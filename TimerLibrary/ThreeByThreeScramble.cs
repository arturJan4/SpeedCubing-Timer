using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    public class ThreeByThreeScramble : IGenerateScrambleInterface
    {
        // TODO - comment scramble
        // TODO - check for more stuff
        public List<Move> GenerateScramble()
        {
            const int moveNumber = 20; //official WCA regulations
            const int rowsAtOnce = 1;
            List<Move> moveList = new List<Move>(moveNumber);

            int i = moveNumber;
            Move prevMove = Move.getRandomMove(rowsAtOnce);
            moveList.Add(prevMove);
            --i;
            while(i != 0)
            {
                Move nextMove = Move.getRandomMove(rowsAtOnce);
                if(nextMove.ToStringRepresentation() != prevMove.ToStringRepresentation())
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
