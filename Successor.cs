using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreesGraphs
{
    //https://www.geeksforgeeks.org/inorder-successor-in-binary-search-tree/
    //Time: O(H) where H is the height of the tree
    public class SuccessorTreeNode
    {
        public object val;
        public SuccessorTreeNode left;
        public SuccessorTreeNode right;
        public SuccessorTreeNode parent;

        public SuccessorTreeNode(object data)
        {
            val = data;
            left = right = parent;
        }
    }

    public class Successor
    {
        static SuccessorTreeNode FindSuccessorFromParent(SuccessorTreeNode node)
        {
            if(node.right != null)
            {
                return GetMin(node.right);
            }

            SuccessorTreeNode parent = node.parent;
            while(parent != null && parent.right == node)
            {
                node = parent;
                parent = parent.parent;
            }
            return parent;
        }

        static SuccessorTreeNode FindSuccessforFromRoot(SuccessorTreeNode root, SuccessorTreeNode node)
        {
            if (node.right != null)
            {
                return GetMin(node.right);
            }

            SuccessorTreeNode successor = null;
            while(root != null)
            {
                if((int)node.val <= (int)root.val)
                {
                    successor = root;
                    root = root.left;
                }
                else if ((int)node.val > (int)root.val)
                {
                    root = root.right;
                }
            }
            return successor;
        }

        static SuccessorTreeNode GetMin(SuccessorTreeNode node)
        {
            while(node.left != null)
            {
                node = node.left;
            }
            return node;
        }

        public static void FindInOrderSuccessor()
        {

        }
    }
}
