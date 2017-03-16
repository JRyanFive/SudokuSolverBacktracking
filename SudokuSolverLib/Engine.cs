using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverLib
{
    public class Engine
    {
        public Board Board { get; set; }

        public Engine()
        {
            int size = 9;
            Node[,] nodes = new Node[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    nodes[j, i] = new Node();
                }
            }
            this.Board = new Board(nodes);
        }

        public bool Solver(Algorithm algorithm)
        {
            var board = Board;
            var result = algorithm.Solver(ref board);
            if (true)
            {
                Board = board;
            }

            return result;
        }

        public void SetValue(int x, int y, int value)
        {
            Board.Nodes[x, y].Value = value;
            Board.Nodes[x, y].Locked = value == 0 ? false : true;
        }

        public void Clear()
        {
            foreach (var item in Board.Nodes)
            {
                item.Value = 0;
                item.Locked = false;
            }
        }
    }
}
