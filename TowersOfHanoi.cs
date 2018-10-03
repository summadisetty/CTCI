using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RecursionAndDynamicProgramming
{
    //https://www.geeksforgeeks.org/c-program-for-tower-of-hanoi/
    //Time complexity: O(2^N)
    public class TowersOfHanoi
    {
        // C# recursive function to solve  
        // tower of hanoi puzzle 
        static void TowerOfHanoi(int n, char origin, char destination, char buffer)
        {
            if (n == 1)
            {
                Console.WriteLine("Move disk 1 from rod " + origin + " to rod " + destination);
                return;
            }
            TowerOfHanoi(n - 1, origin, buffer, destination);
            Console.WriteLine("Move disk " + n + " from rod " + origin + " to rod " + destination);
            TowerOfHanoi(n - 1, buffer, destination, origin);
        }

        public static void PrintSteps()
        {
            // Number of disks 
            int n = 4;

            // A, B and C are names of rods 
            TowerOfHanoi(n, 'A', 'C', 'B');
        } 
    }
}
