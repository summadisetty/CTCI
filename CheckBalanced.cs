using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreesGraphs
{
    public class CheckBalanced
    {
        static int GetHeight(TreeNode node)
        {
            if (node == null)
                return 0;

            int leftHeight = GetHeight(node.left);
            int rightHeight = GetHeight(node.right);

            return (1 + Math.Max(leftHeight, rightHeight));
        }

        static bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            int heightdifference = GetHeight(root.left) - GetHeight(root.right);
            if (Math.Abs(heightdifference) > 1)
            {
                return false;
            }
            else
            {
                return IsBalanced(root.left) && IsBalanced(root.right);
            }
        }

        public static void BalancedTree()
        {
            TreeNode root = new TreeNode(5);
            root.left = new TreeNode(10);
            root.right = new TreeNode(15);
            root.left.left = new TreeNode(20);
            root.left.right = new TreeNode(25);
            root.right.left = new TreeNode(30);
            root.right.right = new TreeNode(35);
            Console.WriteLine(" Is Tree Balanced : " + CheckBalance(root));
            root.right.right.right = new TreeNode(40);
            root.right.right.right.right = new TreeNode(45);
            Console.WriteLine(" Is Tree Balanced : " + CheckBalance(root));
        }

        static bool CheckBalance(TreeNode root)
        {
            int result = IsBalancedUsingDFS(root);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static int IsBalancedUsingDFS(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int leftH = IsBalancedUsingDFS(root.left);
            if (leftH == -1)
            {
                return -1;
            }
            int rightH = IsBalancedUsingDFS(root.right);
            if (rightH == -1)
            {
                return -1;
            }
            int diff = leftH - rightH;
            if (Math.Abs(diff) > 1)
            {
                return -1;
            }
            return 1 + Math.Max(leftH, rightH);
        }
    }
}
