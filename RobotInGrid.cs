using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RecursionAndDynamicProgramming
{
   //https://www.geeksforgeeks.org/count-possible-paths-top-left-bottom-right-nxm-matrix/
    //https://algorithms.tutorialhorizon.com/print-all-paths-from-top-left-to-bottom-right-in-two-dimensional-array/
    public class RobotInGrid
    {
        static void FindPathFromSource(int[,] grid, int r, int c, string path)
        {
            if(r==grid.GetLength(0)-1)
            {
                for(int iCol = c;iCol < grid.GetLength(1);iCol++)
                {
                    path = path + " - " + grid[r, iCol]; 
                }
                Console.WriteLine(path);
                return;
            }

            if (c == grid.GetLength(1) - 1)
            {
                for (int iRow = r; iRow < grid.GetLength(0); iRow++)
                {
                    path = path + " - " + grid[iRow, c];
                }
                Console.WriteLine(path);
                return;
            }

            path = path + " - " + grid[r, c];

            FindPathFromSource(grid, r + 1, c, path);
            FindPathFromSource(grid, r, c + 1, path);
            //FindPathFromSource(grid, r + 1, c + 1, path); //diagonal if allowed
        }

        static void FindPathFromDestination(int[,] grid, int r, int c, string path)
        {
            if (r == 0)
            {
                for (int iCol = c; iCol >= 0; iCol--)
                {
                    path = path + " - " + grid[r, iCol];
                }
                Console.WriteLine(path);
                return;
            }

            if (c == 0)
            {
                for (int iRow = r; iRow >= 0; iRow--)
                {
                    path = path + " - " + grid[iRow, c];
                }
                Console.WriteLine(path);
                return;
            }

            path = path + " - " + grid[r, c];

            FindPathFromDestination(grid, r - 1, c, path);
            FindPathFromDestination(grid, r, c - 1, path);
            //FindPathFromDestination(grid, r - 1, c - 1, path); //diagonal if allowed
        }

        public static void PrintPaths()
        {
            int[,] grid = { { 1, 2, 3 }, { 4, 5, 6 } };
            FindPathFromSource(grid, 0, 0, "");
            Console.WriteLine();
            FindPathFromDestination(grid, 1, 2, "");
        } 
    }
}
