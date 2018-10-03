using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    public class Intersection
    {
        //Time Complexity: O(m+n)
        //Auxiliary Space: O(1)
        static int FindMergingNode(ListNode head1, ListNode head2)
        {
            //get length
            int l1 = GetLength(head1);
            int l2 = GetLength(head2);

            //get merging node
            if (l1 > l2)
            {
                head1 = GetMergingNode(head1, l1 - l2);
            }
            else
            {
                head2 = GetMergingNode(head2, l2 - l1);
            }

            ListNode current1 = head1;
            ListNode current2 = head2;

            while (current1 != null && current2 != null)
            {
                if ((int)current1.val == (int)current2.val)
                {
                    return (int)current1.val;
                }
                current1 = current1.next;
                current2 = current2.next;
            }

            return 0;
        }

        //get length of linked list
        static int GetLength(ListNode node)
        {
            int iCount = 0;
            while (node != null)
            {
                iCount++;
                node = node.next;
            }
            return iCount;
        }

        //iterate nodes up till specified length
        static ListNode GetMergingNode(ListNode node, int length)
        {
            for (int i = 0; i < length; i++)
            {
                node = node.next;
            }
            return node;
        }

        public static void IntersectingPoint()
        {
            ListNode head1 = null;
            ListNode head2 = null;

            // creating first linked list 
            head1 = new ListNode(3);
            head1.next = new ListNode(6);
            head1.next.next = new ListNode(15);
            head1.next.next.next = new ListNode(15);
            head1.next.next.next.next = new ListNode(30);

            // creating second linked list 
            head2 = new ListNode(10);
            head2.next = new ListNode(15);
            head2.next.next = new ListNode(30);

            Console.WriteLine("The node of intersection is " + FindMergingNode(head1, head2));

        }

    }
}
