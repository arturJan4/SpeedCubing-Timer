using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    public class Scramble
    {
        private IGenerateScrambleInterface GenerateInterface;
        public List<Move> Moves{get;}
        public string Representation { get; }
        // TODO - comment strategy here
        // TODO - add 2x2 and 4x4 scramble strategy
        public Scramble(IGenerateScrambleInterface strategy)
        {
            GenerateInterface = strategy;
            Moves = strategy.GenerateScramble();
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < Moves.Count; ++i)
            {
                if(i == Moves.Count - 1)
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
