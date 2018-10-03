using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    public class DeleteMiddleNode
    {
        static bool DeleteNode(ListNode node)
        {
            if (node == null || node.next == null)
                return false;

            node.val = node.next.val;
            node.next = node.next.next;
            return true;
        }

        public static void DeleteMidNode()
        {
            ListNode node = new ListNode("one");
            if (DeleteNode(node))
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
