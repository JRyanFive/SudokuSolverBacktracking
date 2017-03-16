using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Core
{
    public abstract class Cell
    {
        public abstract void Add(Cell cell);
        public abstract void Reset();
    }
}
