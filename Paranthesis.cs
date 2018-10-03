using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RecursionAndDynamicProgramming
{
    //https://algorithms.tutorialhorizon.com/generate-all-valid-parenthesis-strings-of-length-2n-of-given-n/
    public class Paranthesis
    {
        public static void ValidParentheses(int openP, int closeP, String str)
        {
            if (openP == 0 && closeP == 0) // means all opening and closing in string, print it
                Console.WriteLine(str);

            if (openP > closeP) // means closing parentheses is more than open ones
                return;

            if (openP > 0)
                ValidParentheses(openP - 1, closeP, str + "("); // put ( and reduce the count by 1
            if (closeP > 0)
                ValidParentheses(openP, closeP - 1, str + ")"); // put ) and reduce the count by 1
        }

        static void PrintParentheses(int n)
        {
            ValidParentheses(n, n, "");
        }

        public static void PrintParentheses()
        {
            // TODO Auto-generated method stub
            int n = 2;
            PrintParentheses(n);
        }
    }
}
