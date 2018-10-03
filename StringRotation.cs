using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    //Time for IsSubString = O(A + B) (strings of length A and B)
    //Time of IsRotation Alg: O(N)
    public class StringRotation
    {
        static bool IsRotation(string s1, string s2)
        {
            if(s1.Length != s2.Length) return false;

            string s3 = s1 + s1; //waterbottlewaterbottle

            return IsSubString(s3, s2);
        }

        static bool IsSubString(string longerstring, string substring)
        {
            return longerstring.Contains(substring);
        }

        public static void IsRotation()
        {
            string s1 = "waterbottle";
            string s2 = "erbottlewat";

            if (IsRotation(s1, s2))
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }
    }
}
