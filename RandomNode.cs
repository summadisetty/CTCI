using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TreesGraphs
{
    //https://www.geeksforgeeks.org/binary-search-tree-set-2-delete/

    public class RandomNode
    {
        static void InsertInOrder(TreeNode root, int d)
        {
            /* If the tree is empty, return a new node */
            if (root == null)
            {
                root = new TreeNode(d);
            }

            else if (d <= (int)root.val)
            {
                if (root.left == null)
                {
                    root.left = new TreeNode(d);
                }
                else
                {
                    InsertInOrder(root.left, d);
                }
            }
            else
            {
                if (root.right == null)
                {
                    root.right = new TreeNode(d);
                }
                else
                {
                    InsertInOrder(root.right, d);
                }
            }

            root.size++;
        }

        static TreeNode GetRandomNode1(TreeNode root)
        {
            if (root == null) return null;

            Random random = new Random();
            int i = random.Next(0,root.size);
            return GetIthNode(root, i);
        }

        static TreeNode GetIthNode(TreeNode root, int i)
        {
            int leftSize = root.left != null ? root.left.size : 0;
            if (i < leftSize)
            {
                return GetIthNode(root.left, i);
            }
            else if (i == leftSize)
            {
                return root;
            }
            else
            {
                //skipping over leftSize + 1 nodes, so subtract them
                return GetIthNode(root.right, i - (leftSize + 1));
            }
        }

        static int InorderArray(TreeNode root, int[] arr, int index)
        {
            if (root == null)
            {
                return index;
            }

            index = InorderArray(root.left, arr, index);
            arr[index++] = (int)root.val;
            index = InorderArray(root.right, arr, index);
            return index;
        }

        static TreeNode GetRandomNode2(TreeNode root, int[] arr)
        {
            Random random = new Random();
            int i = random.Next(0, arr.Length - 1);

            return FindNode(root, arr[i]);
        }

        static TreeNode FindNode(TreeNode root, int d)
        {
            if (d == (int)root.val)
            {
                return root;
            }
            else if (d <= (int)root.val)
            {
                return root.left != null ? FindNode(root.left, d) : null;
            }
            else if (d > (int)root.val)
            {
                return root.right != null ? FindNode(root.right, d) : null;
            }
            return null;
        }

        // This method mainly calls deleteRec()
        static void DeleteKey(TreeNode root, int key)
        {
            root = DeleteRec(root, key);
        }

        /* A recursive function to insert a new key in BST */
        static TreeNode DeleteRec(TreeNode root, int key)
        {
            /* Base Case: If the tree is empty */
            if (root == null) return root;

            /* Otherwise, recur down the tree */
            if (key < (int)root.val)
                root.left = DeleteRec(root.left, key);
            else if (key > (int)root.val)
                root.right = DeleteRec(root.right, key);

            // if key is same as root's key, then This is the node
            // to be deleted
            else
            {
                // node with only one child or no child
                if (root.left == null)
                    return root.right;
                else if (root.right == null)
                    return root.left;

                // node with two children: Get the inorder successor (smallest
                // in the right subtree)
                root.val = MinValue(root.right);

                // Delete the inorder successor
                root.right = DeleteRec(root.right, (int)root.val);
            }

            root.size--;
            return root;
        }

        static int MinValue(TreeNode root)
        {
            int minv = (int)root.val;
            while (root.left != null)
            {
                minv = (int)root.left.val;
                root = root.left;
            }
            return minv;
        }

        // A utility function to do inorder traversal of BST
        static void PrintInorderRec(TreeNode root)
        {
            if (root != null)
            {
                PrintInorderRec(root.left);
                Console.Write(root.val + " ");
                PrintInorderRec(root.right);
            }
        }

        public static void GenerateRandomNode()
        {
            TreeNode root = new TreeNode(50);

            InsertInOrder(root, 30);
            InsertInOrder(root, 20);
            InsertInOrder(root, 40);
            InsertInOrder(root, 70);
            InsertInOrder(root, 60);
            InsertInOrder(root, 80);

            Console.WriteLine("Inorder traversal of the given tree");
            PrintInorderRec(root);

            Console.WriteLine("\nDelete 20");
            DeleteKey(root, 20);
            Console.WriteLine("Inorder traversal of the modified tree");
            PrintInorderRec(root);

            Console.WriteLine("\nDelete 30");
            DeleteKey(root, 30);
            Console.WriteLine("Inorder traversal of the modified tree");
            PrintInorderRec(root);

            Console.WriteLine("\nDelete 50");
            DeleteKey(root, 50);
            Console.WriteLine("Inorder traversal of the modified tree");
            PrintInorderRec(root);

            for(int i=1;i<=root.size;i++)
            {
                TreeNode node = GetRandomNode1(root);
                Console.WriteLine("\nRandom Node generated: " + node.val);
            }           
        }
    }
}
