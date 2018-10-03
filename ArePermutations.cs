using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    //https://www.geeksforgeeks.org/check-if-two-arrays-are-permutations-of-each-other/
    //Time: O(N)
    public class ArePermutations
    {
        // Returns true if arr1[] and arr2[] are permutations of each other 
        static Boolean arePermutations(int[] arr1, int[] arr2)
        {
            // Creates an empty hashMap hM 
            Dictionary<int, int> hM = new Dictionary<int, int>();

            if (arr1.Length != arr2.Length)
                return false;

            // Traverse through the first array and add elements to hash map 
            for (int i = 0; i < arr1.Length; i++)
            {
                int x = arr1[i];
                if (!hM.ContainsKey(x))
                    hM.Add(x, 1);
                else
                {
                    int k = hM[x];  
                    hM[x] = k + 1;
                }
            }

            // Traverse through second array and check if every element is 
            // present in hash map 
            for (int i = 0; i < arr2.Length; i++)
            {
                int x = arr2[i];

                // If element is not present in hash map or element 
                // is not present less number of times 
                if (!hM.ContainsKey(x) || hM[x] <= 0)
                    return false;

                int k = hM[x];
                hM[x] = k - 1;
            }
            return true;
        }

        public static void CheckIfPermutations()
        {
            //int[] arr1 = { 2, 1, 3, 5, 4, 3, 2 };
            //int[] arr2 = { 3, 2, 2, 4, 5, 3, 1 };

            int[] arr1 = { 2, 1, 3, 5, 4 };
            int[] arr2 = { 3, 2, 1, 4, 1 };

            if (arePermutations(arr1, arr2))
                Console.WriteLine("Arrays are permutations of each other");
            else
                Console.WriteLine("Arrays are NOT permutations of each other");
        }
    }
}
