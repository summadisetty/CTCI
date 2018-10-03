using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreesGraphs
{
    //https://www.geeksforgeeks.org/graph-and-its-representations/
    public class Graph
    {
        public LinkedList<int>[] adjListArray;
        public int vertices;

        public Graph(int v)
        {
            adjListArray = new LinkedList<int>[v];

            vertices = v;
            for(int i=0;i<vertices;i++)
            {
                adjListArray[i] = new LinkedList<int>();
            }
        }
    }
    class AdjacencyList
    {
        // Adds an edge to an undirected graph
        static void AddEdge(Graph graph, int src, int dest)
        {
            // Add an edge from src to dest. 
            graph.adjListArray[src].AddFirst(dest);

            // Since graph is undirected, add an edge from dest
            // to src also
            graph.adjListArray[dest].AddFirst(src);
        }

        // A utility function to print the adjacency list 
        // representation of graph
        static void PrintGraph(Graph graph)
        {
            for (int v = 0; v < graph.vertices; v++)
            {
                Console.WriteLine("Adjacency list of vertex " + v);
                Console.Write("head");
                foreach (int pCrawl in graph.adjListArray[v])
                {
                    Console.Write(" -> " + pCrawl);
                }
                Console.WriteLine("\n");
            }
        }

        // Driver program to test above functions
        public static void ImplementGraphUsingAdjacencyList()
        {
            // create the graph given in above figure
            int V = 5;
            Graph graph = new Graph(V);
            AddEdge(graph, 0, 1);
            AddEdge(graph, 0, 4);
            AddEdge(graph, 1, 2);
            AddEdge(graph, 1, 3);
            AddEdge(graph, 1, 4);
            AddEdge(graph, 2, 3);
            AddEdge(graph, 3, 4);

            // print the adjacency list representation of 
            // the above graph
            PrintGraph(graph);
        }
    }
}
