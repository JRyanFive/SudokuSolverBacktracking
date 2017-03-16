using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverLib
{
    public class Node
    {
        public int Value { get; set; }

        public bool Locked { get; set; }
    }
}
