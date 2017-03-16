using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Core
{
    public class SudokuCell : Cell, INotifyPropertyChanged
    {


        public int Column { get; set; }
        public int Row { get; set; }
        public bool IsFreeze { get; set; }

        private int value { get; set; }
        public int? Value
        {
            get
            {
                if (value != 0)
                {
                    return value;
                }
                return null;
            }
            set { this.value = value.Value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override void Add(Cell cell)
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            SetValue(0);
            IsFreeze = false;
        }

        public void SetValue(int value)
        {
            this.value = value;
            //this.Disable = true;
            NotifyPropertyChanged();
        }

        public Cell Get(int index)
        {
            throw new NotImplementedException();
        }

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
