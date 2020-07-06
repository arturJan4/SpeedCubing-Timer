using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TimerLibrary.Tests
{
    public class SolveTest
    {
        [Theory]
        [InlineData(CubeType.TWO)]
        [InlineData(CubeType.THREE)]
        [InlineData(CubeType.FOUR)]
        public void Ctr_ShouldCreate(CubeType cubetype)
        {
            var expectedIsDNF = false;
            var expectedSolveTime = 0;
            var expectedTypeOfCube = cubetype;

            Solve actual = new Solve(cubetype);
            Assert.Equal(expectedIsDNF, actual.IsDNF);
            Assert.Equal(expectedSolveTime, actual.SolveTime);
            Assert.Equal(expectedTypeOfCube, actual.TypeOfCube);
        }
    }
}
