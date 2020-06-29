using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    public interface IViewInterface
    {
        void SetController(Controller controller);
        void TimerInteract();
        string ClockTime { get; set; }
        string Scramble { get; set; }
        string DNF { get; set; }
    }
}
