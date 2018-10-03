using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class OneEditAway
    {
        // Returns true if edit distance 
        // between s1 and s2 is one, else false
        static bool IsEditDistanceOne(String s1,
                                      String s2)
        {

            // Find lengths of given strings
            int m = s1.Length, n = s2.Length;

            // If difference between lengths is 
            // more than 1, then strings can't 
            // be at one distance
            if (Math.Abs(m - n) > 1)
                return false;

            // Count of edits
            int count = 0;
            int i = 0, j = 0;

            while (i < m && j < n)
            {
                // If current characters 
                // don't match
                if (s1[i] != s2[j])
                {
                    if (count == 1)
                        return false;

                    // If length of one string is
                    // more, then only possible edit
                    // is to remove a character
                    if (m > n)
                        i++;
                    else if (m < n)
                        j++;

                     // If lengths of both 
                    // strings is same
                    else
                    {
                        i++;
                        j++;
                    }

                    // Increment count of edits 
                    count++;
                }

                // If current characters match
                else
                {
                    i++;
                    j++;
                }
            }

            // If last character is extra 
            // in any string
            if (i < m || j < n)
                count++;

            return count == 1;
        }

        // Driver code
        public static void IsEditDistanceOne()
        {
            String s1 = "hk";
            String s2 = "ghl";
            if (IsEditDistanceOne(s1, s2))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
