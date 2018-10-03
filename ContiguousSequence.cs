using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class Sequence
    {
        public int startIndex;
        public int endIndex;
        public int maxSum;
    }

    //The solution is given by the Kadane's algorithm. Also called Largest Sum Contigous SubArray
    //https://www.youtube.com/watch?v=kekmCQXYwQ0
    public class ContiguousSequence
    {
        static Sequence CalculateMaxSequence(int[] arr)
        {
            int maxSum = 0, sum = 0;
            int start = 0, end = 0, s = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum + arr[i];
                if (maxSum < sum)
                {
                    maxSum = sum;
                    start = s;
                    end = i;
                }

                if (sum < 0)
                {
                    sum = 0;
                    s = i + 1;
                }
            }

            Sequence item = new Sequence()
            {
                startIndex = start,
                endIndex = end,
                maxSum = maxSum
            };

            return item;
        }

        public static void GetLargestSumContigousSubArray()
        {
            int[] arr = { 4, -3, -2, 2, 3, 1, -2, -3, 4, 2, -6, -3, -1, 3, 1, 2 };

            Sequence item = CalculateMaxSequence(arr);

            Console.WriteLine(String.Format("Largest sum of contiguous subarray {0} thru {1} is {2}", item.startIndex, item.endIndex, item.maxSum));
        }
    }
}
