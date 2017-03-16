using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverLib
{
    public abstract class Algorithm
    {
        public abstract bool Solver(ref Board board);
    }
}
