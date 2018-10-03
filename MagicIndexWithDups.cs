using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RecursionAndDynamicProgramming
{
    //https://www.geeksforgeeks.org/find-fixed-point-value-equal-index-given-array-duplicates-allowed/
    public class MagicIndexWithDups
    {
        static int FindMagicIndex(int[] arr, int start, int end)
        {
            if (start <= end)
            {
                int mid = (start + end) / 2;
                if (arr[mid] == mid) // check for magic index
                    return mid;

                int left = FindMagicIndex(arr, start, Math.Min(arr[mid], mid - 1));
                if (left >= 0)
                    return left;

                return FindMagicIndex(arr, Math.Max(arr[mid], mid + 1), end);
            }
            return -1;
        }

        public static void PrintMagicIndex()
        {
            int[] arr = { -10, -5, 1, 2, 2, 3, 4, 7, 9, 12, 13 };
            int magicIndex = FindMagicIndex(arr, 0, arr.Length - 1);
            Console.Write("Magic Index for: { ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    Console.Write(arr[i] + " ");
                }
                else
                {
                    Console.Write(arr[i] + ", ");
                }
            }
            Console.Write("} is " + magicIndex);
        }
    }
}
