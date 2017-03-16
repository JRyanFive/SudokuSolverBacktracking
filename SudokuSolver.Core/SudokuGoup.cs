using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Core
{
    public class SudokuGoup : Cell
    {
        private Cell[] cells;
        private int counter;
        public SudokuGoup(int size)
        {
            cells = new Cell[size];
            counter = 0;
        }

        public override void Add(Cell cell)
        {
            cells[counter] = cell;
            counter++;
        }

        public Cell Get(int index)
        {
            return cells[index];
        }

        public override void Reset()
        {
            for (int i = 0; i < cells.Length; i++)
            {
                cells[i].Reset();
            }
        }

        public void SetValue(int value)
        {
            throw new NotImplementedException();
        }

        public int GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
