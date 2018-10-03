using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreesGraphs
{
    public class BinaryTree
    {
        TreeNode InsertLevelOrder(int[] arr, TreeNode node, int index)
        {
            if (arr.Length > index)
            {
                node = new TreeNode(arr[index]);

                node.left = InsertLevelOrder(arr, node.left, 2 * index + 1);
                node.right = InsertLevelOrder(arr, node.right, 2 * index + 2);
            }

            return node;
        }

        // Function to print tree nodes in InOrder fashion 
        void InOrder(TreeNode node)
        {
            if (node != null)
            {
                InOrder(node.left);
                Console.Write(node.val + " ");
                InOrder(node.right);
            }
        }

        public void ImplementBinaryTree()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 6, 6, 6 };
            TreeNode node = null;
            node = InsertLevelOrder(arr, node, 0);
            InOrder(node);
        }
    }
}
