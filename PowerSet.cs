using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.RecursionAndDynamicProgramming
{
    //https://www.ideserve.co.in/learn/generate-all-subsets-of-a-set-recursion
    //Time Complexity: O(n2^n)
    public class PowerSet
    {
        static List<List<int>> FindAllSubsets(int[] set)
	    {
            List<List<int>> allSubsets = new List<List<int>>();

            allSubsets.Add(new List<int>());

            FindAllSubsets(allSubsets, set, 0);
	
	        return allSubsets;
	    }

        static void FindAllSubsets(List<List<int>> allSubsets, int[] set, int currIndex)
	    {
	         
	        if (currIndex == set.Length)
	        {
	            return;
	        }

            int allSubSetsSize = allSubsets.Count;  
	        List<int> newSet;

            for (int i = 0; i < allSubSetsSize; i++)
            {
                newSet = CloneSet(allSubsets[i]);
                newSet.Add(set[currIndex]);
                allSubsets.Add(newSet);
            }	        
	         
	        FindAllSubsets(allSubsets, set, currIndex+1);
	    }

        static List<int> CloneSet(List<int> input)
	    {
            List<int> clone = new List<int>();

            for (int i = 0; i < input.Count; i++)
	        {
                clone.Add(input[i]);
            }
	        
	        return clone;
	    }

        public static void PrintAllSubsets()
        {
            int[] set = { 1, 2, 3 };

            List<List<int>> allSubsets = FindAllSubsets(set);
            for(int i=0;i<allSubsets.Count;i++)
            {
                Console.Write("[");
                List<int> subset = allSubsets[i];
                for(int j=0;j<subset.Count;j++)
                {
                    if (j == subset.Count - 1)
                    {
                        Console.Write(subset[j]);
                    }
                    else
                    {
                        Console.Write(subset[j] + ", ");
                    }
                    
                }
                Console.Write("]");
                Console.WriteLine();
            }

        }
    }
}
