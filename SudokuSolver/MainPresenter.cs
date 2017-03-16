using SudokuSolver.Models;
using SudokuSolverLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SudokuSolver
{
    class MainPresenter
    {
        private Engine engine { get; set; }

        private NodeModel[,] nodeModels { get; set; }

        public MainPresenter()
        {
            engine = new Engine();

            InitModel();
        } 

        public List<List<NodeModel>> Cells
        {
            get
            {
                List<List<NodeModel>> lsts = new List<List<NodeModel>>();
                for (int i = 0; i < 9; i++)
                {
                    lsts.Add(new List<NodeModel>());
                    for (int j = 0; j < 9; j++)
                    {
                        lsts[i].Add(nodeModels[j, i]);
                    }
                }
                return lsts;
            }
        }

        public void Solver()
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();

            var result = engine.Solver(new BacktrackingAlgorithm());
            stopWatch.Stop();

            if (result)
            {
                for (int i = 0; i < 9; i++)
                {                   
                    for (int j = 0; j < 9; j++)
                    {
                        nodeModels[j, i].Value = engine.Board.Nodes[j, i].Value;
                        nodeModels[j, i].NotifyPropertyChanged();
                    }
                }
                MessageBox.Show("Total time to solve: " + stopWatch.ElapsedMilliseconds + "ms");
            }
            else
            {
                MessageBox.Show("Cannot solve sudoku");
            }
        }

        public void SetValue(int x, int y, int value)
        {
            nodeModels[x, y].Value = value;
            engine.SetValue(x, y, value);
        }

        public void Clear()
        {
            InitModel();
            engine.Clear();
        }

        private void InitModel()
        {
            nodeModels = new NodeModel[9, 9];

            int size = 9;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    nodeModels[j, i] = new NodeModel() { X = j, Y = i };
                }
            }
        }
    }
}
