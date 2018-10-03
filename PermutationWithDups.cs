using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RecursionAndDynamicProgramming
{
    public class PermutationWithDups
    {
        // Prints all distinct permutations in str[0..n-1] 
        static void Permute(string str, int l, int r)
        {
            if (l == r)
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    // Proceed further for str[i] only if it  
                    // doesn't match with any of the characters 
                    // after str[index] 
                    bool check = ShouldSwap(str, l, i);
                    if (check)
                    {
                        str = Swap(str, l, i);
                        Permute(str, l + 1, r);
                        str = Swap(str, l, i);
                    }
                }
            }
        }   


        // Returns true if str[curr] does not matches with any of the 
        // characters after str[start] 
        static bool ShouldSwap(string str, int start, int curr)
        {
            for (int i = start; i < curr; i++)
                if (str[i] == str[curr])
                    return false;
            return true;
        }

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
            string str = "112";
            int n = str.Length;
            Permute(str, 0, n - 1);
        }
    }
}
