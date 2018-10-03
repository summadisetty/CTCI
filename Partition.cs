using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    public class Partition
    {
        static ListNode PartitionList(ListNode head, int x)
        {
            ListNode lowerHead = null, lowerTail = null, greaterHead = null, greaterTail = null;
            ListNode current = head;

            while(current!=null)
            {
                if((int)current.val < x)
                {
                    if(lowerHead == null)
                    {
                        lowerHead = current;
                        lowerTail = current;
                    }
                    else
                    {
                        lowerTail.next = current;
                        lowerTail = current;
                    }
                }
                else
                {
                    if(greaterHead == null)
                    {
                        greaterHead = current;
                        greaterTail = current;
                    }
                    else
                    {
                        greaterTail.next = current;
                        greaterTail = current;
                    }
                }
                current = current.next;
            }

            if(lowerHead == null)
            {
                return greaterHead;
            }

            lowerTail.next = greaterHead;
            return lowerHead;
        }

        public static void PartitionList()
        {
            ListNode node = new ListNode(1);
            ListNode head = PartitionList(node, 5);
            Console.WriteLine("Partitioned list");
        }
    }
}
