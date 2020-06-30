﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary.Scrambles
{
    public class FourByFourScramble : IGenerateScrambleInterface
    {
        private enum MoveType
        {
            L, // lower
            R, // right
            U, // upper
            D, // down
            F, // front
            B, // only for 4x4 scrambles
        };
        public List<Move> GenerateScramble()
        {
            const int moveNumber = 40; //official WCA regulations
            const int rowsAtOnce = 2;
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