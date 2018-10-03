using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RecursionAndDynamicProgramming
{
    //https://www.geeksforgeeks.org/flood-fill-algorithm-implement-fill-paint/
    //Time Complexity: O(N), where N is the number of pixels in the image. We might process every pixel.
    //Space Complexity: O(N), the size of the implicit call stack when calling dfs.
    public class PaintFill
    {
        static void FillColor(int[,] arr, int m, int n, int oldColor, int newColor)
        {
            if (m < 0 || m >= arr.GetLength(0) || n < 0 || n >= arr.GetLength(1))
                return;

            if (arr[m, n] != oldColor)
                return;

            if (arr[m, n] == oldColor)
            {
                arr[m, n] = newColor;

                FillColor(arr, m - 1, n, oldColor, newColor);
                FillColor(arr, m + 1, n, oldColor, newColor);
                FillColor(arr, m, n - 1, oldColor, newColor);
                FillColor(arr, m, n + 1, oldColor, newColor);
            }
        }

        public static void FillColor()
        {
            int[,] arr = {{1,1,1},{1,1,0},{1,0,1}};

            int sr = 1, sc = 1;

            int oldColor = arr[sr, sc];
            FillColor(arr, sr, sc, oldColor, 2);

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("[");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j == arr.GetLength(1) - 1)
                    {
                        Console.Write(arr[i, j]);
                    }
                    else
                    {
                        Console.Write(arr[i, j] + ", ");
                    }
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }
    }
}
