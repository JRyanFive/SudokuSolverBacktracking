using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Core
{
    public class SudokuCell : ICell, INotifyPropertyChanged
    {
        private int value { get; set; }

        public int Column { get; set; }
        public int Row { get; set; }
        public bool IsFreeze { get; set; }

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

        public void Add(ICell cell)
        {
            throw new NotImplementedException();
        }

        public void Reset()
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

        public ICell Get(int index)
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
