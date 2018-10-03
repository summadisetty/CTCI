using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    //CompressStringWithoutStringBuilder - https://gist.github.com/kinshuk4/1a4d64f884b5d51792a992977366e40c
    public class StringCompression
    {
        //This operation takes O(P + K^2) where P is size of the original string and K is the number of character sequences. For example, if the string is aabccdeeaa, then there are six character sequences. 
        //string conactenation operates in O(N^2) time
        //On each conactenation, a new copy of string is created and the two strings are copied over.
        static string CompressStringWithoutStringBuilder(string str)
        {
            //aaabcccaa
            int iLength = str.Length;
            string compressedString = string.Empty;

            char prevChar = str[0];
            int charCount = 1;

            for (int i = 1; i < iLength; i++)
            {
                char currentChar = str[i];

                if (prevChar == currentChar)
                {
                    charCount++;
                }
                else
                {
                    compressedString = compressedString + prevChar + Convert.ToString(charCount);
                    prevChar = currentChar;
                    charCount = 1;
                }
            }

            compressedString = compressedString + prevChar + Convert.ToString(charCount);

            if (compressedString.Length > iLength)
                return str;
            else
                return compressedString;
        }

        //This takes O(P) time where P is teh size of teh original string
        //append operation of string builder takes O(1) time since it appends to the end of the array.
        static string CompressStringUsingStringBuilder(string str)
        {
            //aaabcccaa
            int iLength = str.Length;
            StringBuilder compressedString = new StringBuilder();

            char prevChar = str[0];
            int charCount = 1;

            for (int i = 1; i < iLength; i++)
            {
                char currentChar = str[i];

                if (prevChar == currentChar)
                {
                    charCount++;
                }
                else
                {
                    compressedString.Append(prevChar);
                    compressedString.Append(Convert.ToString(charCount));
                    prevChar = currentChar;
                    charCount = 1;
                }
            }

            compressedString.Append(prevChar);
            compressedString.Append(Convert.ToString(charCount));

            if (compressedString.Length > iLength)
                return str;
            else
                return compressedString.ToString();
        }

        public static void PrintCompressedString()
        {
            string originalString = "aaabcccaa";
            string compressedString = CompressStringWithoutStringBuilder(originalString);

            Console.WriteLine(string.Format("Compressed string of {0} is {1}", originalString, compressedString));

            compressedString = CompressStringUsingStringBuilder(originalString);

            Console.WriteLine(string.Format("Compressed string of {0} is {1}", originalString, compressedString));
        }
    }
}
