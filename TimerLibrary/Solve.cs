using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerLibrary
{
    public class Solve
    {
        public double SolveTime { get; set; }
        public string Scramble { get;}
        public bool IsDNF { get; set; }
        public CubeType TypeOfCube { get; }
        public Solve(CubeType cubeType)
        {
            // TODO - solve compatibility and scalability issues
            Scramble = (new Scramble(new ThreeByThreeScramble())).Representation;
            SolveTime = 0.0;
            IsDNF = false;
            TypeOfCube = cubeType;
        }
    }
}
