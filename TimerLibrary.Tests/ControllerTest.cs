using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TimerLibrary.Tests
{
    public class ControllerTest
    {
        //TODO - moq test
        public void Ctr_ShouldCreate()
        {
            Mock<IViewInterface> moqInterface = new Mock<IViewInterface>();
            Controller controller = new Controller(moqInterface.Object);

            // correct state
            Assert.True(controller.IsWating());
            Assert.False(controller.IsSolving());
            Assert.False(controller.IsInspecting());

            // generates scramble
            Assert.NotNull(controller.GetScramble());
            
            // begins at time zero
            Assert.Equal(0, controller.GetTime().TotalMilliseconds);

            
        }
    }
}
