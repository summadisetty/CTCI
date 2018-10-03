using LeetCode.LinkedList;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreesGraphs
{
    //https://algorithms.tutorialhorizon.com/in-a-binary-tree-create-linked-lists-of-all-the-nodes-at-each-depth/
    //Time complexity: O(N)
    //Similar problem: Print binary tree, each level in one line
    //Create a ArrayList of Linked List Nodes.
    //Do the level order traversal using queue(Breadth First Search). Click here to know about how to level order traversal.
    //For getting all the nodes at each level, before you take out a node from queue, store the size of the queue in a variable, say you call it as levelNodes.
    //Now while levelNodes>0, take out the nodes and print it and add their children into the queue. add these to a linked list
    //After this while loop put a line break and create a new linked list
    public class ListOfDepths
    {
        static ArrayList GetList(TreeNode root)
        {
            ArrayList al = new ArrayList();
            Queue<TreeNode> q = new Queue<TreeNode>();

            q.Enqueue(root);

            while(q.Count != 0)
            {
                int iLevelCount = q.Count;
                ListNode head = null;
                ListNode current = null;

                while(iLevelCount > 0)
                {
                    TreeNode tn = q.Dequeue();
                    ListNode ln = new ListNode(tn.val);

                    if(head == null)
                    {
                        head = ln;
                        current = ln;
                    }
                    else
                    {
                        current.next = ln;
                        current = current.next;
                    }

                    if(tn.left != null)
                    {
                        q.Enqueue(tn.left);
                    }
                    if(tn.right != null)
                    {
                        q.Enqueue(tn.right);
                    }
                    iLevelCount--;
                }

                al.Add(head);
            }

            return al;
        }

        public static void PrintListOfDepths()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);

            ArrayList al = GetList(root);

            foreach(ListNode ln in al)
            {
                ListNode current = ln;
                while(current!=null)
                {
                    Console.Write(current.val + " ");
                    current = current.next;
                }
                Console.WriteLine();
            }
        }
    }
}
