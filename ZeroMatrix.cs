using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    //ModifyMatrix: https://www.geeksforgeeks.org/a-boolean-matrix-question/
    public class ZeroMatrix
    {
        static void SetZeroMatrix(int[,] matrix)
        {
            for(int iRow = 0; iRow < matrix.GetLength(0);iRow++)
            {
                for(int iCol = 0;iCol < matrix.GetLength(1);iCol++)
                {
                    if(matrix[iRow,iCol] == 0)
                    {
                        NullifyMatrix(matrix);
                        break;

                    }
                }
            }
        }

        static void NullifyMatrix(int[,] matrix)
        {
            for (int iRow = 0; iRow < matrix.GetLength(0); iRow++)
            {
                for (int iCol = 0; iCol < matrix.GetLength(1); iCol++)
                {
                    matrix[iRow, iCol] = 0;
                }
            }
        }

        //Time Complexity: O(M*N)
        //Auxiliary Space: O(1)
        public static void ModifyMatrix(int[,] mat)
        {

            // variables to check 
            // if there are any 0
            // in first row and column
            bool row_flag = false;
            bool col_flag = false;

            // updating the first
            // row and col if 1
            // is encountered
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    if (i == 0 && mat[i, j] == 0)
                        row_flag = true;

                    if (j == 0 && mat[i, j] == 0)
                        col_flag = true;

                    if (mat[i, j] == 0)
                    {
                        mat[0, j] = 0;
                        mat[i, 0] = 0;
                    }

                }
            }

            // Modify the input matrix mat[] 
            // using the first row and first
            // column of Matrix mat
            for (int i = 1; i < mat.GetLength(0); i++)
            {
                for (int j = 1; j < mat.GetLength(1); j++)
                {

                    if (mat[0, j] == 0 || mat[i, 0] == 0)
                    {
                        mat[i, j] = 0;
                    }
                }
            }

            // modify first row
            // if there was any 1
            if (row_flag == true)
            {
                for (int i = 0; i < mat.GetLength(1); i++)
                {
                    mat[0, i] = 0;
                }
            }

            // modify first col if
            // there was any 1
            if (col_flag == true)
            {
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    mat[i, 0] = 0;
                }
            }
        }

        /* A utility function 
        to print a 2D matrix */
        public static void PrintMatrix(int[,] mat)
        {
            for (int i = 0;
                     i < mat.GetLength(0); i++)
            {
                for (int j = 0;
                         j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j] + " ");
                }
                Console.Write("\n");
            }
        }

        public static void SetZeroMatrix()
        {
            int[,] a = new int[3, 4] {
               {1, 0, 0, 1},
               {0, 0, 1, 0},
               {0, 0, 0, 0}
            };

            Console.Write("Input Matrix :\n");
            PrintMatrix(a);
            SetZeroMatrix(a);
            Console.Write("Matrix After " +
                         "Modification :\n");
            PrintMatrix(a);

            a = new int[3,3] {
               {1,2,3},
               {5,0,7},
               {9,10,0}
            };
            Console.Write("Input Matrix :\n");
            PrintMatrix(a);
            ModifyMatrix(a);
            Console.Write("Matrix After " +
                          "Modification :\n");
            PrintMatrix(a);
        }
    }
}
