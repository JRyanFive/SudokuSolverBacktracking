using SudokuSolverLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolverTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePlay gameplay = new GamePlay();
            var solel = gameplay.Solver(new BacktrackingAlgorithm());

            var node = gameplay.Board.Nodes;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(node[j, i].Value+" ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
