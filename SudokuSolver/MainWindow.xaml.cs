using SudokuSolver.Core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SudokuSolver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameBoard gameBoard;
        public MainWindow()
        {
            InitializeComponent();

            gameBoard = new GameBoard();
            gameBoard.Init();
     
            this.DataContext = gameBoard;
        }

        private void OnMenuExit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnSolver(object sender, RoutedEventArgs e)
        {
            var t = Task.Run(() =>
            {
                var result = gameBoard.Solve();
                if (result)
                {
                    MessageBox.Show("Total time to solve: " + gameBoard.SolvedTime + "ms");
                }
                else
                {
                    MessageBox.Show("Cannot solve sudoku");
                }
            });
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var inputPad = new NumberPad();
            inputPad.Owner = this;
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            inputPad.Left = point.X + 20;
            inputPad.Top = point.Y - (inputPad.Height / 2);
            inputPad.ShowDialog();

            var num = inputPad.Number;
            SudokuCell cell = (sender as Label).DataContext as SudokuCell;
            if (num == 0)
            {
                cell.Reset();
            }
            else
            {
                cell.SetValue(num);
                cell.IsFreeze = true;
            }
        }

        private void OnClear(object sender, RoutedEventArgs e)
        {
            gameBoard.Clear();
        }
    }
}
