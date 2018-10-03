using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    public class EnglishInt
    {
        static string[] smalls = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

        static string[] tens = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        static string hundred = "Hundred";

        static string[] bigs = { "", "Thousand", "Million", "Billion" };

        //19,253,456
        static string GeneratePhrase(int num)
        {
            LinkedList<string> parts = new LinkedList<string>();
            int chunkCount = 0;

            while(num > 0)
            {
                if (num % 1000 != 0)
                {
                    string chunk = ConvertToChunk(num % 1000) + " " + bigs[chunkCount];
                    parts.AddFirst(chunk);                    
                }
                num = num / 1000;
                chunkCount++;
            }

            return ListToString(parts);
        }

        static string ConvertToChunk(int num)
        {
            LinkedList<string> parts = new LinkedList<string>();
            /* convert hundreds place */
            if(num >= 100)
            {
                parts.AddLast(smalls[num / 100]);
                parts.AddLast(hundred);
                num = num % 100;
            }

            /* convert tens place */
            if(num >= 10 && num <= 19)
            {
                parts.AddLast(smalls[num]);
            }
            else if(num >= 20)
            {
                parts.AddLast(tens[num / 10]);
                num = num % 10;
            }

            /* convert ones place */
            if(num >= 1 && num<10)
            {
                parts.AddLast(smalls[num]);
            }

            return ListToString(parts);
        }

        static string ListToString(LinkedList<string> parts)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string part in parts)
            {
                sb.Append(part);
                sb.Append(" ");
            }
            return sb.ToString();
        }
        
        public static void PrintNumberToWord()
        {
            int num = 19253456;
            string word = GeneratePhrase(num);
            Console.WriteLine(string.Format("English Phrase of {0} is {1}", num, word));
        }

        
    }
}
