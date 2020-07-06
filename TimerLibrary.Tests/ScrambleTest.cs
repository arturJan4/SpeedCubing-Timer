using TimerLibrary.Scrambles;
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
            for (int i = 1; i < tested.Moves.Count; ++i)
            {
                Move curr = tested.Moves[i];
                Assert.NotEqual(prev, curr);
                prev = curr;
            }

            string[] splitted = tested.Representation.Split(' ');

            Assert.Equal(20, tested.Moves.Count);
            Assert.Equal(20, splitted.Length);
        }

        [Fact]
        public void Scramble2x2_isValid()
        {
            Scramble tested = new Scramble(new TwoByTwoScramble());

            Move prev = tested.Moves[0];
            for (int i = 1; i < tested.Moves.Count; ++i)
            {
                Move curr = tested.Moves[i];
                Assert.NotEqual(prev, curr);
                Assert.NotEqual(MoveType.D, curr.TypeOfMove);
                Assert.NotEqual(MoveType.L, curr.TypeOfMove);
                prev = curr;
            }

            string[] splitted = tested.Representation.Split(' ');

            Assert.Equal(10, tested.Moves.Count);
            Assert.Equal(10, splitted.Length);
        }

        [Fact]
        public void Scramble4x4_isCorrectLength()
        {
            Scramble tested = new Scramble(new FourByFourScramble());

            Move prev = tested.Moves[0];
            for (int i = 1; i < tested.Moves.Count; ++i)
            {
                Move curr = tested.Moves[i];
                Assert.NotEqual(prev, curr);
                prev = curr;
            }

            string[] splitted = tested.Representation.Split(' ');

            Assert.Equal(40, tested.Moves.Count);
            Assert.Equal(40, splitted.Length);
        }
    }
}
