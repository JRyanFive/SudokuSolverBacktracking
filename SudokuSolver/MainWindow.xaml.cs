using SudokuSolver.Models;
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
        MainPresenter presenter;
        public MainWindow()
        {
            InitializeComponent();

            presenter = new MainPresenter();      
     
            this.DataContext = presenter;
        }

        private void OnMenuExit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void OnSolver(object sender, RoutedEventArgs e)
        {
            var t = Task.Run(() =>
            {
                presenter.Solver();
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
            NodeModel cell = (sender as Label).DataContext as NodeModel;
            presenter.SetValue(cell.X, cell.Y, num);
        }

        private void OnClear(object sender, RoutedEventArgs e)
        {
            presenter.Clear();
        }
    }
}
