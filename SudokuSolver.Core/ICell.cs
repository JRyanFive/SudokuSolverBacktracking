using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Core
{
    public interface ICell
    {
        //ICell Get(int index);
        void Add(ICell cell);

        //void SetValue(int value);
        //int GetValue();
        void Reset();
       
    }
}
