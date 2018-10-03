using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Arrays
{
    //https://www.geeksforgeeks.org/given-a-sequence-of-words-print-all-anagrams-together/
    // class for each word of duplicate array
    //Total time = O(NMLogM + MNLogN) = O(MN * (LogM + LogN))
    class Word
    {
        public String str;  // to store word itself
        public int index; // index of the word in the original array

        // constructor
        public Word(String str, int index)
        {
            this.str = str;
            this.index = index;
        }

    }

    // class to represent duplicate array.
    class DupArray
    {
        public Word[] array;  // Array of words
        public int size;   // Size of array

        // constructor
        public DupArray(String[] str, int size)
        {
            this.size = size;
            array = new Word[size];

            // One by one copy words from the 
            // given wordArray to dupArray
            int i;
            for (i = 0; i < size; ++i)
            {
                // create a word Object with the 
                // str[i] as str and index as i
                array[i] = new Word(str[i], i);
            }

        }
    }

     // Compare two words. Used in Arrays.sort() for 
     // sorting an array of words
     class compStr : Comparer<Word>
     {
            public override int Compare(Word a, Word b)
            {
                int iComp = a.str.CompareTo(b.str);
                return iComp;
            }
        }

    public class PrintAnagramsTogether
    {  
        // Given a list of words in wordArr[],
        static void printAnagramsTogether(String[] wordArr, int size)
        {
            // Step 1: Create a copy of all words present
            // in given wordArr. The copy will also have 
            // original indexes of words
            DupArray dupArray = new DupArray(wordArr, size);

            // Step 2: Iterate through all words in 
            // dupArray and sort individual words.
            //M - number of characters in each string
            //N - total size of array
            //Sorting a string of M characters - O(MLogM)
            //Sorting all N strings - O(N * MLogM)
            int i;
            for (i = 0; i < size; ++i)
            {
                char[] char_arr = dupArray.array[i].str.ToCharArray();
                Array.Sort(char_arr);
                dupArray.array[i].str = new string(char_arr);
            }

            // Step 3: Now sort the array of words in 
            // dupArray
            //Compare all strings of M character length - O(M)
            //Sort all N words - O(NLogN)
            //Compare and Sort all words - O(M * NLogN)
            Array.Sort(dupArray.array, new compStr());

            // Step 4: Now all words in dupArray are together,
            // but these words are changed. Use the index 
            // member of word struct to get the corresponding
            // original word
            for (i = 0; i < size; ++i)
                Console.WriteLine(wordArr[dupArray.array[i].index] + " ");
        }

        // Driver program to test above functions
        public static void PrintAnagrams()
        {
            String[] wordArr = { "cat", "dog", "tac", "god", "act" };
            int size = wordArr.Length;
            printAnagramsTogether(wordArr, size);
        }
    }    
}

