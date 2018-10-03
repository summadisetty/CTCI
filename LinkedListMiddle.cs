using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    public class ListNode
    {
        public object val;
        public ListNode next;
        public ListNode(object x) { val = x; }
    }

    public class LinkedListMiddle
    {
        public ListNode MiddleNode(ListNode head)
        {
            ListNode[] arr = new ListNode[100];
            int iCount = 0;
            while (head.next != null)
            {
                arr[iCount++] = head;
                head = head.next;
            }

            return arr[iCount / 2];
        }
    }
}
