using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverLib
{
    public class BacktrackingAlgorithm : Algorithm
    {
        private Board board;
        public override bool Solver(ref Board board)
        {
            this.board = board;
            if (BackTracking(0,0))
            {
                board = this.board;
                return true;
            }

            return false;
        }

        private bool BackTracking(int col, int row)
        {
            int nNextRow = row;
            int nNextCol = col;
            bool isLastCell = !NextRowCol(ref nNextCol, ref nNextRow);

            if (board.Nodes[col, row].Locked)
            {
                if (isLastCell)
                    return true;

                return BackTracking(nNextCol, nNextRow);
            }

            List<int> possibilities = new List<int>();

            for (int val = 1; val < 10; val++)
            {
                bool bFound = false;

                //check row and col
                for (int i = 0; i < 9 && !bFound; i++)
                {
                    if (board.Nodes[i, row].Value == val)
                    {
                        bFound = true;
                    }

                    if (board.Nodes[col, i].Value == val)
                    {
                        bFound = true;
                    }
                }

                int nSubGridSize = 3;
                int subGridRowMax = (nSubGridSize * ((row / nSubGridSize) + 1)) - 1;
                int subGridColMax = (nSubGridSize * ((col / nSubGridSize) + 1)) - 1;

                for (int y = subGridRowMax - (nSubGridSize - 1); y <= subGridRowMax; y++)
                {
                    for (int x = subGridColMax - (nSubGridSize - 1); x <= subGridColMax; x++)
                    {
                        if (board.Nodes[x, y].Value == val)
                        {
                            bFound = true;
                        }
                    }
                }

                if (!bFound)
                {
                    possibilities.Add(val);
                }
            }

            if (isLastCell && possibilities.Count > 0)
            {
                board.Nodes[col, row].Value = possibilities[0];
                return true;
            }

            foreach (var val in possibilities)
            {
                board.Nodes[col, row].Value = val;

                if (BackTracking(nNextCol, nNextRow))
                {
                    return true;
                }
            }

            board.Nodes[col, row].Value = 0;
            return false;
        }

        private bool NextRowCol(ref int col, ref int row)
        {
            col++;
            if (col == 9)
            {
                col = 0;
                row++;
            }
            if (row == 9)
            {
                row = 0;
                return false;
            }
            return true;
        }
    }
}
