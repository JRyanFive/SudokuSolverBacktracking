using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Core
{
    public class CellFactory
    {
        private Dictionary<int, SudokuCell> cellFac = new Dictionary<int, SudokuCell>();

        public SudokuCell this[int key]
        {
            get
            {
                if (!cellFac.ContainsKey(key))
                {
                    cellFac.Add(key, new SudokuCell());
                }

                return cellFac[key];
            }
            set
            {
                cellFac[key] = value;
            }
        }

        //public SudokuCell this[int colum,int row]
        //{
        //    get
        //    {
        //        if (!cellFac.ContainsKey(key))
        //        {
        //            cellFac.Add(key, new SudokuCell());
        //        }

        //        return cellFac[key];
        //    }
        //    set
        //    {
        //        cellFac[key] = value;
        //    }
        //}
    }
}
