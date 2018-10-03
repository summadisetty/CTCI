using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreesGraphs
{
    //https://algorithms.tutorialhorizon.com/determine-whether-given-binary-tree-is-binary-search-treebst-or-not/
    //Time: O(N)
    //Space: O(LogN)
    public class ValidateBST
    {
        static int? prevNode = null;

        static bool IsBST1(TreeNode node)
        {
            if (node == null)
                return true;

            if (!IsBST1(node.left)) return false;

            if(prevNode != null && (int)node.val <= prevNode)
            {
                return false;
            }

            prevNode = (int) node.val;

            if (!IsBST1(node.right)) return false;

            return true;
        }

        static bool IsBST2(TreeNode node, int? min, int? max)
        {
            if (node == null) return true;            

            if ((min != null && (int)node.val <= min) || (max != null && (int)node.val > max)) return false;

            if (!IsBST2(node.left, min, (int)node.val) || !IsBST2(node.right, (int)node.val, max)) 
                return false;

            return true;            
        }

        static void Inorder(TreeNode root)
        {
            if (root != null)
            {
                Inorder(root.left);
                Console.Write("  " + root.val);
                Inorder(root.right);
            }
        }

        public static void IsBST()
        {
            TreeNode root = new TreeNode(20);
            root.left = new TreeNode(10);
            root.right = new TreeNode(30);
            root.left.left = new TreeNode(5);
            root.left.right = new TreeNode(15);
            root.right.left = new TreeNode(25);
            root.right.right = new TreeNode(35);
            Inorder(root);
            Console.WriteLine();
            Console.WriteLine("Is Tree BST ?? METHOD 1 : " + IsBST1(root));
            Console.WriteLine("Is Tree BST ?? METHOD 2 : " + IsBST2(root, int.MinValue, int.MaxValue));
            
            root.left.right.right = new TreeNode(40);
            Inorder(root);
            Console.WriteLine();
            Console.WriteLine("Is Tree BST ?? METHOD 1 : " + IsBST1(root));
            Console.WriteLine("Is Tree BST ?? METHOD 2 : " + IsBST2(root, int.MinValue, int.MaxValue));
        }
    }
}
