using System.Collections.Generic;

namespace TimerLibrary.Scrambles
{
    /// <summary>
    /// Interface for Strategy Pattern implementation
    /// </summary>
    public interface IGenerateScrambleInterface
    {
        List<Move> GenerateScramble();
    }
}
