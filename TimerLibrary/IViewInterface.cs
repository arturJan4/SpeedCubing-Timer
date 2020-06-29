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
        string Hours { get; set; }

    }
}
