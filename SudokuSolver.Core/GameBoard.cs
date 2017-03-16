using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Core
{
    public class GameBoard
    {
        public long SolvedTime { get; set; }
        private List<SudokuCell> cells = new List<SudokuCell>();
        private CellFactory cellFactory = new CellFactory();

        int size = 9;
        //Cell[] sudokuGroup;
        SudokuCell[,] board;
        public void Init()
        {
            //sudokuGroup = new Cell[size];
            board = new SudokuCell[9, 9];
            int cellId = 0;
            for (int i = 0; i < size; i++)
            {
                //sudokuGroup[i] = new SudokuGoup(size);

                for (int j = 0; j < size; j++)
                {
                    var cell = cellFactory[cellId];
                    cell.Column = j;
                    cell.Row = i;
                    //sudokuGroup[i].Add(cellFactory[cellId]);
                    cells.Add(cell);
                    board[j, i] = cell;

                    cellId++;
                }
            }
        }

        public List<List<SudokuCell>> Cells
        {
            get
            {
                List<List<SudokuCell>> lsts = new List<List<SudokuCell>>();
                for (int i = 0; i < 9; i++)
                {
                    lsts.Add(new List<SudokuCell>());
                    for (int j = 0; j < 9; j++)
                    {
                        lsts[i].Add(board[j, i]);
                    }
                }
                return lsts;
            }
        }

        public bool Solve()
        {
            bool result = false;
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            result = BackTracking(0, 0);

            stopWatch.Stop();
            SolvedTime = stopWatch.ElapsedMilliseconds;
            return result;
        }
        
        private bool BackTracking(int col, int row)
        {
            int nNextRow = row;
            int nNextCol = col;
            bool isLastCell = !NextRowCol(ref nNextCol, ref nNextRow);

            if (board[col, row].IsFreeze)
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
                    if (board[i, row].Value != null && board[i, row].Value.Value == val)
                    {
                        bFound = true;
                    }

                    if (board[col, i].Value != null && board[col, i].Value.Value == val)
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
                        if (board[x, y].Value != null && board[x, y].Value.Value == val)
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
                board[col, row].SetValue(possibilities[0]);
                return true;
            }

            foreach (var val in possibilities)
            {
                board[col, row].SetValue(val);

                if (BackTracking(nNextCol, nNextRow))
                {
                    return true;
                }
            }

            board[col, row].SetValue(0);
            return false;
        }

        private bool IsValidPosition()
        {
            var dicCheck = new Dictionary<int, bool>();

            //check row
            for (int i = 0; i < 81; i += 9)
            {
                dicCheck = new Dictionary<int, bool>();
                for (int j = 0; j < 9; j++)
                {
                    if (cellFactory[i + j].Value != null)
                    {
                        if (!dicCheck.ContainsKey(cellFactory[i + j].Value.Value))
                        {
                            dicCheck[cellFactory[i + j].Value.Value] = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            //check col
            for (int i = 0; i < 9; i++)
            {
                dicCheck = new Dictionary<int, bool>();
                for (int j = 0; j < 81; j += 9)
                {
                    if (cellFactory[i + j].Value != null)
                    {
                        if (!dicCheck.ContainsKey(cellFactory[i + j].Value.Value))
                        {
                            dicCheck[cellFactory[i + j].Value.Value] = true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            //check block
            int[] pivot = new int[] { 0, 3, 6, 27, 30, 33, 54, 57, 60 };
            for (int i = 0; i < pivot.Length; i++)
            {
                dicCheck = new Dictionary<int, bool>();

                for (int j = pivot[i]; j < pivot[i] + 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (cellFactory[j + k * 9].Value != null)
                        {
                            if (!dicCheck.ContainsKey(cellFactory[j + k * 9].Value.Value))
                            {
                                dicCheck[cellFactory[j + k * 9].Value.Value] = true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
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


        public void Clear()
        {
            //for (int i = 0; i < sudokuGroup.Length; i++)
            //{
            //    sudokuGroup[i].Reset();
            //}
        }
    }
}
