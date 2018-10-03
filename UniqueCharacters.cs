using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    //Time: O(N)
    public class UniqueCharacters
    {
       static bool IsUnique(string value)
        {
            char[] char_array = value.ToCharArray();
            Hashtable ht = new Hashtable();

           bool[] char_set = new bool[128];
            for(int i= 0; i<char_array.Length;i++)
            {
                if (ht.ContainsKey(char_array[i]))
                    return false;
                else
                    ht.Add(char_array[i], i);
            }
            return true;
        }

        public static void IsUnique()
        {
            string str = "UniqueChar";

            if (IsUnique(str))
                Console.WriteLine("Given string has unique characters");
            else
                Console.WriteLine("Given string does not have unique characters");

        }
    }
}
