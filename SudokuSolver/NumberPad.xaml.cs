using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SudokuSolver
{
    /// <summary>
    /// Interaction logic for NumberPad.xaml
    /// </summary>
    public partial class NumberPad : Window
    {
        public int Number { get; private set; }

        public NumberPad()
        {
            InitializeComponent();
        }

        private void OnNumberClick(object sender, RoutedEventArgs e)
        {
            Number = int.Parse((sender as Button).Content.ToString());
            this.Close();
        }

        private void OnClearClick(object sender, RoutedEventArgs e)
        {
            Number = 0;
            this.Close();
        }

        public void Open()
        {
            this.ShowDialog();
        }
    }
}
