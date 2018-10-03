using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    class RotateMatrix
    {
        /*old: 1 2 3         New: 3 6 9
         *     4 5 6              2 5 8
         *     7 8 9              1 4 7
         *                                              */
        //Time: O(M*N) M: No of rows in given matrix and N: No of columns in given matrix

        //RotateGivenMatrix2: https://www.geeksforgeeks.org/inplace-rotate-square-matrix-by-90-degrees/
        //RotateGivenMatrix3: https://www.geeksforgeeks.org/rotate-matrix-90-degree-without-using-extra-space-set-2/
       
        static int[,] RotateGivenMatrix1(int[,] matrix)
        {
            int[,] newMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];

            int iNewRow = 0, iNewColumn = 0;

            for (int iOldCol = matrix.GetLength(1) - 1; iOldCol >= 0; iOldCol--)
            {
                iNewColumn = 0;
                for (int iOldRow = 0; iOldRow < matrix.GetLength(0); iOldRow++)
                {
                    newMatrix[iNewRow, iNewColumn] = matrix[iOldRow, iOldCol];
                    iNewColumn++;
                    
                }
                iNewRow++;
            }
            return newMatrix;
        }

        static int[,] RotateGivenMatrix2(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            // Consider all 
            // squares one by one
            for (int x = 0; x < n / 2; x++)
            {
                // Consider elements 
                // in group of 4 in 
                // current square
                for (int y = x; y < n - 1 - x; y++)
                {
                    // store current cell 
                    // in temp variable
                    int temp = matrix[x, y];

                    // move values from 
                    // right to top
                    matrix[x, y] = matrix[y, n - 1 - x];

                    // move values from
                    // bottom to right
                    matrix[y, n - 1 - x] = matrix[n - 1 - x, n - 1 - y];

                    // move values from
                    // left to bottom
                    matrix[n - 1 - x, n - 1 - y] = matrix[n - 1 - y, x];

                    // assign temp to left
                    matrix[n - 1 - y, x] = temp;
                }
            }
            return matrix;
        }

        // Function to anticlockwise
        // rotate matrix by 90 degree
        static int[,] RotateGivenMatrix3(int[,] arr)
        {
            Transpose(arr);
            ReverseColumns(arr);

            return arr;
        }

        // Function for do
        // transpose of matrix
        static void Transpose(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
                for (int j = i; j < arr.GetLength(1); j++)
                {
                    int temp = arr[j, i];
                    arr[j, i] = arr[i, j];
                    arr[i, j] = temp;
                }
        }

        // After transpose we swap
        // elements of column one
        // by one for finding left
        // rotation of matrix by
        // 90 degree
        static void ReverseColumns(int[,] arr)
        {
            int C = arr.GetLength(1);
            for (int i = 0; i < C; i++)
                for (int j = 0, k = C - 1;
                     j < k; j++, k--)
                {
                    int temp = arr[j, i];
                    arr[j, i] = arr[k, i];
                    arr[k, i] = temp;
                }
        }        

        public static void PrintRotatedMatrix()
        {
            int[,] a = new int[3, 3] {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            };

            int[,] newMatrix = RotateGivenMatrix1(a);
            foreach (int i in newMatrix)
            {
                Console.Write("{0} ", i);
            }

            newMatrix = RotateGivenMatrix2(a);
            foreach (int i in newMatrix)
            {
                Console.Write("{0} ", i);
            }

            newMatrix = RotateGivenMatrix3(a);
            foreach (int i in newMatrix)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
