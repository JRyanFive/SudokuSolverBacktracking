using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverLib
{
    public class Board
    {
        public Node[,] Nodes { get; set; }

        public Board(Node[,] nodes)
        {
            this.Nodes = nodes;
        }
    }
}
