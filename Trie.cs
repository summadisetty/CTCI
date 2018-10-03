using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreesGraphs
{
    //https://www.geeksforgeeks.org/trie-insert-and-search/
    //Time complexity - O(K) where K = length of key string
    //Space Complexity - O(Alphabet_Size * K * N) where Alphabet_Size = 26 and N in number of keys
    public class TrieNode
    {
        public TrieNode[] children = new TrieNode[26];
        public bool isEndOfWord;
        const int Alphabet_Size = 26;

        public TrieNode()
        {
            isEndOfWord = false;
            for (int i = 0; i < Alphabet_Size; i++)
                children[i] = null;
        }
    }

    public class Trie
    {
        static TrieNode root;

        // If not present, inserts key into trie
        // If the key is prefix of trie node, 
        // just marks leaf node
        static void insert(String key)
        {
            int level;
            int length = key.Length;
            int index;

            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    pCrawl.children[index] = new TrieNode();

                pCrawl = pCrawl.children[index];
            }

            // mark last node as leaf
            pCrawl.isEndOfWord = true;
        }

        // Returns true if key presents in trie, else false
        static bool search(String key)
        {
            int level;
            int length = key.Length;
            int index;
            TrieNode pCrawl = root;

            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';

                if (pCrawl.children[index] == null)
                    return false;

                pCrawl = pCrawl.children[index];
            }

            return (pCrawl != null && pCrawl.isEndOfWord);
        }
     
        // Driver
        public static void ImplementTrieInsertSearch()
        {
            // Input keys (use only 'a' through 'z' and lower case)
            String[] keys = {"the", "a", "there", "answer", "any",
                         "by", "bye", "their"};

            String[] output = { "Not present in trie", "Present in trie" };


            root = new TrieNode();

            // Construct trie
            int i;
            for (i = 0; i < keys.Length; i++)
                insert(keys[i]);

            // Search for different keys
            if (search("the") == true)
                Console.WriteLine("the --- " + output[1]);
            else Console.WriteLine("the --- " + output[0]);

            if (search("these") == true)
                Console.WriteLine("these --- " + output[1]);
            else Console.WriteLine("these --- " + output[0]);

            if (search("their") == true)
                Console.WriteLine("their --- " + output[1]);
            else Console.WriteLine("their --- " + output[0]);

            if (search("thaw") == true)
                Console.WriteLine("thaw --- " + output[1]);
            else Console.WriteLine("thaw --- " + output[0]);
        }
    }
}
