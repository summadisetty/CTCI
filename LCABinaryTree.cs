using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreesGraphs
{
    //https://algorithms.tutorialhorizon.com/lowest-common-ancestor-in-a-binary-tree-not-binary-search-tree/
    //https://www.geeksforgeeks.org/lowest-common-ancestor-binary-tree-set-1/
    //Time: O(N)
    public class LCABinaryTree
    {
        static TreeNode GetLCA(TreeNode root, TreeNode n1, TreeNode n2)
        {
            if (root == null)
            {
                return null;
            }
            else
            {
                if ((int)root.val == (int)n1.val || (int)root.val == (int)n2.val)
                {
                    return root;
                }
                TreeNode left = GetLCA(root.left, n1, n2);
                TreeNode right = GetLCA(root.right, n1, n2);

                if (left != null && right != null)
                {
                    return root;
                }
                if (left != null)
                {
                    return left;
                }
                else if (right != null)
                {
                    return right;
                }
                return null;
            }
        }

        public static void GetLowestCommonAncestor()
        {
            TreeNode n1 = new TreeNode(8);
            TreeNode n2 = new TreeNode(7);  

            TreeNode root = new TreeNode(20);            
            root.left = n1;
            root.right = new TreeNode(36);
            root.left.left = n2;        
            root.left.right = new TreeNode(12);
            root.right.left = new TreeNode(26);
            root.right.right = new TreeNode(46);
            root.left.right.left = new TreeNode(10);
            root.left.right.right = new TreeNode(14);
            root.right.right.left = new TreeNode(40);
            root.right.right.right = new TreeNode(50);

            TreeNode x = GetLCA(root, n1, n2);
            Console.WriteLine("Lowest Common Ancestor (" + n1.val + ", " + n2.val + " ) is " + x.val);
        }
    }
}
