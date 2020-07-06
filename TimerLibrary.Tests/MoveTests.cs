using Xunit;

namespace TimerLibrary.Tests
{
    public class MoveTests
    {
        [Theory]
        [InlineData(MoveType.L, 1, false, false)]
        [InlineData(MoveType.F, 2, false, true)]
        public void Ctr_ShouldCreate(MoveType moveExp, uint rowsExp, bool doubleExp, bool antiClockwiseExp)
        {
            //Arrange

            //Act
            Move tested = new Move(moveExp, rowsExp, doubleExp, antiClockwiseExp);
            MoveType moveActual = tested.TypeOfMove;
            uint rowsActual = tested.RowsAtOnce;
            bool doubleActual = tested.IsDouble;
            bool antiClockwiseActual = tested.IsAnticlockwise;

            //Asert
            Assert.Equal(moveExp, moveActual);
            Assert.Equal(rowsExp, rowsActual);
            Assert.Equal(doubleExp, doubleActual);
            Assert.Equal(antiClockwiseExp, antiClockwiseActual);
        }

        [Theory]
        [InlineData(MoveType.L, 1, false, false, "L")]
        [InlineData(MoveType.F, 1, false, true, "F'")]
        [InlineData(MoveType.R, 1, true, false, "R2")]
        [InlineData(MoveType.U, 2, true, false, "U2(2)")]
        [InlineData(MoveType.D, 2, false, true, "D'(2)")]
        public void ToStringRepresentation_ShouldConvert(MoveType move, uint rows, bool doubleG, bool antiClockwise, string expected)
        {
            Move tested = new Move(move, rows, doubleG, antiClockwise);
            string actual = tested.ToStringRepresentation();

            Assert.Equal(expected, actual);
        }
    }
}
