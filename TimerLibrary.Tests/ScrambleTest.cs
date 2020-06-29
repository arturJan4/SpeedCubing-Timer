using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLibrary;
using Xunit;

namespace TimerLibrary.Tests
{
    public class ScrambleTest
    {
        [Fact]
        public void Scramble3x3_isCorrectLength()
        {
            Scramble tested = new Scramble(new ThreeByThreeScramble());

            Move prev = tested.Moves[0];
            for(int i = 1; i < 20; ++i)
            {
                Move curr = tested.Moves[i];
                Assert.NotEqual(prev, curr);
                prev = curr;
            }
          
            string[] splitted = tested.Representation.Split(' ');

            Assert.Equal(20, tested.Moves.Count);
            Assert.Equal(20, splitted.Length);

        }
    }
}
