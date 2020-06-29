using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    /// <summary>
    /// Interface for Strategy Pattern implementation
    /// </summary>
    public interface IGenerateScrambleInterface
    {
        List<Move> GenerateScramble();
    }
}
