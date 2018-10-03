using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RecursionAndDynamicProgramming
{
    public class Coins
    {
        static int GetWays(int amount, int[] denoms, int index)
        {
            if (index >= denoms.Length - 1) return 1;
            int denomAmount = denoms[index];
            int ways = 0;
            for (int i = 0; i * denomAmount <= amount; i++)
            {
                int amountRemianing = amount - i * denomAmount;
                ways += GetWays(amountRemianing, denoms, index + 1);
            }
            return ways;
        }

        public static void MakeChange()
        {
            int n = 10;
            int[] denoms = { 25, 10, 5, 1 };
            int ways = GetWays(n, denoms, 0);

            Console.WriteLine("Number of ways representing " + n + " cents: " + ways);
        }
    }
}
