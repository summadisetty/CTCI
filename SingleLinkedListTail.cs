using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    public class SingleLinkedListTail
    {
        static ListNode head = null;
        static ListNode tail = null;

        public static void AddLast(object data)
        {
            ListNode newItem = new ListNode(data);

            if (head == null)
            {
                head = newItem;
                tail = newItem;
            }
            else
            {
                tail.next = newItem;
                tail = newItem;
            }
        }

        public static void AddFirst(object data)
        {
            ListNode newItem = new ListNode(data);

            if (head == null)
            {
                head = newItem;
                tail = newItem;
            }
            else
            {
                newItem.next = head;
                head = newItem;
            }
        }

        public static void PrintAll()
        {
            ListNode current = head;
            while (current.next != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
            Console.WriteLine(current.val);
        }       

        public static void ImplementSingleLinkedListTail()
        {
            AddLast("one");
            AddLast("two");
            AddLast("three");
            AddFirst("First");
            PrintAll();
        }
    }
}
