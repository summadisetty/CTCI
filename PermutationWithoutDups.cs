using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RecursionAndDynamicProgramming
{
    //https://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
    //Time Complexity: O(n*n!) Note that there are n! permutations and it requires O(n) time to print a a permutation
    public class PermutationWithoutDups
    {
        /** 
    * permutation function 
    * @param str string to  
       calculate permutation for 
    * @param l starting index 
    * @param r end index 
    */
        static void Permute(String str, int l, int r)
        {
            if (l == r)
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = Swap(str, l, i);
                    Permute(str, l + 1, r);
                    str = Swap(str, l, i);
                }
            }
        }

        /** 
    * Swap Characters at position 
    * @param a string value 
    * @param i position 1 
    * @param j position 2 
    * @return swapped string 
    */
        static String Swap(String a, int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

        // Driver Code 
        public static void PrintAllPermutations()
        {
            string str = "ABC";
            int n = str.Length;
            Permute(str, 0, n - 1);
        }
    }
}
