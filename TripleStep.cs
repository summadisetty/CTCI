using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RecursionAndDynamicProgramming
{
    public class TripleStep
    {
        //time complexity: O(3^N)
        static int CountWaysNaive(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;

            return CountWaysNaive(n - 3) + CountWaysNaive(n - 2) + CountWaysNaive(n - 1);
        }

        //time complexity: O(N)
        static int CountWaysUsingMemoization(int n, int[] cache)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;

            if (cache[n] > -1)
                return cache[n];

            cache[n] = CountWaysUsingMemoization(n - 3, cache) + CountWaysUsingMemoization(n - 2, cache) + CountWaysUsingMemoization(n - 1, cache);

            return cache[n];
        }

        public static void CountWays()
        {
            int n = 5;

            int[] cache = new int[n + 1];
            for (int i = 0; i < cache.Length; i++)
            {
                cache[i] = -1;
            }

            int ways1 = CountWaysNaive(n);
            Console.WriteLine("Possible ways to run " + n + " steps are: " + ways1);

            int ways2 = CountWaysUsingMemoization(n, cache);
            Console.WriteLine("Possible ways to run " + n + " steps are: " + ways2);
        }
    }
}
