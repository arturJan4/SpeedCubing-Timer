﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary.Scrambles
{
    public class TwoByTwoScramble : IGenerateScrambleInterface
    {
        /// <summary>
        /// Generates a random 2x2 scramble, 
        /// non-repeating sequence of moves, separated with spaces. 
        /// Doesn't use D or L moves. 
        /// </summary>
        /// <returns></returns>
        public List<Move> GenerateScramble()
        {
            const int moveNumber = 10; //official WCA regulations
            const int rowsAtOnce = 1;
            List<Move> moveList = new List<Move>(moveNumber);

            int i = moveNumber;
            Move prevMove = Move.getRandomMove(rowsAtOnce);
            while (!valid(prevMove))
            {
                prevMove = Move.getRandomMove(rowsAtOnce);
            }
            moveList.Add(prevMove);
            --i;
            while (i != 0)
            {
                Move nextMove = Move.getRandomMove(rowsAtOnce);
                while (!valid(nextMove))
                {
                    nextMove = Move.getRandomMove(rowsAtOnce);
                }
                if (nextMove.ToStringRepresentation() != prevMove.ToStringRepresentation())
                {
                    moveList.Add(nextMove);
                    prevMove = nextMove;
                    i--;
                }
            }
            return moveList;
        }
        
        /// <summary>
        /// Checks if Move is valid in 2x2 Scramble
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        private bool valid(Move move)
        {
            if (move.TypeOfMove == MoveType.D ||
                move.TypeOfMove == MoveType.L)
            {
                return false;
            }
            return true;
        }
    }
}
