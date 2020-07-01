using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    /// <summary>
    /// Possible moveTypes, don't include back moves as they're not used in scrambles
    /// </summary>
    public enum MoveType
    {
        L, // lower
        R, // right
        U, // upper
        D, // down
        F, // front
    };
    /// <summary>
    /// CubeTypes as enums to allow further additions of non-standard cubes (like pyraminx)
    /// </summary>
    public enum CubeType
    {
        TWO,   //two by two
        THREE, //three by three
        FOUR,  //four by four      
    }

}
