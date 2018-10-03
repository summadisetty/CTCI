using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreesGraphs
{
    //Time Complexity: O(n)
    //Auxiliary Space : If we don’t consider size of stack for function calls then O(1) otherwise O(n)
    public class TreeNode
    {
        public object val;
        public TreeNode left;
         public TreeNode right;
         public int size;
         public TreeNode(object x) 
         { 
             val = x;
             left = right = null;
         }
    }

    public class TreeTraversal
    {
        // Root of Binary Tree 
        TreeNode root;

        void PreOrder(TreeNode node)
        {
            if (node == null) return;
            Console.Write(node.val);
            PreOrder(node.left);
            PreOrder(node.right);
        }

        void InOrder(TreeNode node)
        {
            if (node == null) return;
            InOrder(node.left);
            Console.Write(node.val);
            InOrder(node.right);
        }

        void PostOrder(TreeNode node)
        {
            if (node == null) return;
            PostOrder(node.left);            
            PostOrder(node.right);
            Console.Write(node.val);
        }

        public void ImplementTreeTraversal()
        {
            root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            Console.WriteLine("Preorder traversal of binary tree is ");
            PreOrder(root);

            Console.WriteLine("\nInorder traversal of binary tree is ");
            InOrder(root);

            Console.WriteLine("\nPostorder traversal of binary tree is ");
            PostOrder(root);
        }       
    }
}
