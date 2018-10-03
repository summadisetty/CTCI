using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreesGraphs
{
    public class RouteBetweenNodes
    {
        //Function to add an edge into the graph
        static void AddEdge(Graph graph, int v, int w) { graph.adjListArray[v].AddLast(w); }

        //prints BFS traversal from a given source s
        static bool IsReachable(Graph graph, int s, int d)
        {
            // Mark all the vertices as not visited(By default set
            // as false)
            bool[] visited = new bool[graph.vertices];

            // Create a queue for BFS
            Queue<int> queue = new Queue<int>();

            // Mark the current node as visited and enqueue it
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                // Dequeue a vertex from queue and print it
                s = queue.Dequeue();

                int n;
                foreach (int pCrawl in graph.adjListArray[s])
                {
                    n = pCrawl;
                    // If this adjacent node is the destination node,
                    // then return true
                    if (n == d)
                        return true;

                    // Else, continue to do BFS
                    if (!visited[n])
                    {
                        visited[n] = true;
                        queue.Enqueue(n);
                    }
                }
            }

            // If BFS is complete without visited d
            return false;
        }

        public static void FindPathBetweenNodes()
        {
            // Create a graph given in the above diagram
            Graph g = new Graph(4);
            AddEdge(g, 0, 1);
            AddEdge(g, 0, 2);
            AddEdge(g, 1, 2);
            AddEdge(g, 2, 0);
            AddEdge(g, 2, 3);
            AddEdge(g, 3, 3);

            int u = 1;
            int v = 3;
            if (IsReachable(g, u, v))
                Console.WriteLine("There is a path from " + u + " to " + v);
            else
                Console.WriteLine("There is no path from " + u + " to " + v);

            u = 3;
            v = 1;
            if (IsReachable(g, u, v))
                Console.WriteLine("There is a path from " + u + " to " + v);
            else
                Console.WriteLine("There is no path from " + u + " to " + v);
        }
    }
}
