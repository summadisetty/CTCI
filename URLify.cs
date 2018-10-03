using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    //https://www.geeksforgeeks.org/urlify-given-string-replace-spaces/
    //Time Complexity : O(n) where n is the true length of the string.
    //Auxiliary Space : O(1) because the above program is an inplace algorithm.
    //https://algorithms.tutorialhorizon.com/replace-all-spaces-in-a-string-with/
    public class URLify
    {
        // Replaces spaces with %20 in-place and returns
        // new length of modified string. It returns -1
        // if modified string cannot be stored in str[]
        static char[] ReplaceSpaces(char[] str, int trueLength)
        {
            // count spaces and find current length
            int space_count = 0, index, i;
            for (i = 0; i < trueLength; i++)
            {
                if (str[i] == ' ')
                {
                    space_count++;
                }                  
            }

            int newLength = trueLength + space_count * 2;
            char[] newstr = new char[newLength];

            index = newLength - 1;

            if (trueLength < str.Length) str[trueLength] = '\0'; //End array
            for (i = trueLength - 1; i >= 0;i-- )
            {
                if(str[i] == ' ')
                {
                    newstr[index] = '0';
                    newstr[index-1] = '2';
                    newstr[index-2] = '%'; 
                    index = index - 3;
                }
                else
                {
                    newstr[index] = str[i];
                    index--;
                }
            }

            return newstr;
        }

        public static void URLifyString()
        {
            string str = "Mr John Smith   ";

            char[] array = str.ToCharArray();
            
            // Prints the replaced string
            char[] newstr = ReplaceSpaces(array, str.Trim().Length);
            for (int i = 0; i < newstr.Length; i++)
            {
                Console.Write(newstr[i]);
            }                
        }
    }
}
