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
        ICell[] sudokuGroup;

        public void Init()
        {
            sudokuGroup = new ICell[size];
            int cellId = 0;
            for (int i = 0; i < size; i++)
            {
                sudokuGroup[i] = new SudokuGoup(size);

                for (int j = 0; j < size; j++)
                {
                    var cell = cellFactory[cellId];
                    cell.Column = j;
                    cell.Row = i;
                    sudokuGroup[i].Add(cellFactory[cellId]);
                    cells.Add(cell);

                    cellId++;
                }
            }
        }

        public List<SudokuCell> Cells
        {
            get { return cells; }
        }

        public bool Solve()
        {
            bool result = false;
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            result = BackTracking(0);

            stopWatch.Stop();
            SolvedTime = stopWatch.ElapsedMilliseconds;
            return result;
        }

        private bool BackTracking(int cellId)
        {
            if (cellId == 81)
            {
                return true;
            }

            if (cellFactory[cellId].IsFreeze)
            {
                return BackTracking(cellId + 1);
            }

            for (int i = 1; i < 10; i++)
            {
                cellFactory[cellId].SetValue(i);

                if (IsValidPosition() && BackTracking(cellId + 1))
                {
                    return true;
                }
                else
                {
                    cellFactory[cellId].SetValue(0);
                }
            }

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
              
        public void Clear()
        {
            for (int i = 0; i < sudokuGroup.Length; i++)
            {
                sudokuGroup[i].Reset();
            }
        }  
    }
}
