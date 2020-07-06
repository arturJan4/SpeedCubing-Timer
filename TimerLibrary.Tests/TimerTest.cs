using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TimerLibrary.Tests
{
    public class TimerTest
    {
        [Fact]
        public void Class_IsSingleton()
        {
            TimerClass timer1 = TimerClass.Instance;
            TimerClass timer2 = TimerClass.Instance;
            Assert.Equal (timer1, timer2);
        }
        [Fact]
        public void EnableDisable_IsWorking()
        {
            Assert.False(TimerClass.Instance.IsWorking());
            Assert.Equal(0, TimerClass.Instance.GetTime().TotalMilliseconds);

            TimerClass.Instance.Enable();
            TimerClass.Instance.Disable();

            Assert.True(TimerClass.Instance.GetTime().TotalMilliseconds > 0);
        }
        [Fact]
        public void Reset_IsValid()
        {
            Assert.False(TimerClass.Instance.IsWorking());
            Assert.Equal(0, TimerClass.Instance.GetTime().TotalMilliseconds);

            TimerClass.Instance.Enable();
            TimerClass.Instance.Reset();

            Assert.False(TimerClass.Instance.GetTime().TotalMilliseconds > 0);
        }
    }
}
