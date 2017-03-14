using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Core
{
    public class SudokuGoup : ICell
    {
        private ICell[] cells;
        private int counter;
        public SudokuGoup(int size)
        {
            cells = new ICell[size];
            counter = 0;
        }

        public void Add(ICell cell)
        {
            cells[counter] = cell;
            counter++;
        }

        public ICell Get(int index)
        {
            return cells[index];
        }

        public void Reset()
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
