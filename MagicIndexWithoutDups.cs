using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RecursionAndDynamicProgramming
{
    //https://algorithms.tutorialhorizon.com/magic-index-find-index-in-sorted-array-such-that-ai-i/
    //Time Complexity: O(Logn)
    public class MagicIndexWithoutDups
    {
        static int FindMagicIndex(int[] arr, int start, int end)
        {
            if (start <= end)
            {
                int mid = (start + end) / 2;
                if (arr[mid] == mid) // check for magic index
                    return mid;
                else if (mid > arr[mid]) // If mid>A[mid] means fixed point might be on the right half of the array
                    return FindMagicIndex(arr, mid + 1, end);
                else if (mid < arr[mid]) // If mid<A[mid] means fixed point might be on the left half of the array
                    return FindMagicIndex(arr, start, mid - 1);
            }
            return -1;
        }

        public static void PrintMagicIndex()
        {
            int[] arr = { -1, 0, 1, 2, 4, 10 };
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
