using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    //AddLast takes O(N) time to insert last node. Instead this can be done in O(1) time. See SingleLinkedListTail.cs
    public class SingleLinkedList
    {
        static ListNode head = null;

        public static void AddLast(object data)
        {
            ListNode newItem = new ListNode(data);

            if(head == null)
            {
                head = newItem;
            }
            else
            {
                ListNode current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newItem;
            }
        }

        public static void AddFirst(object data)
        {
            ListNode newItem = new ListNode(data);

            if (head == null)
            {
                head = newItem;
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

        static void InsertAfter(ListNode prevNode, object data)
        {
            ListNode newItem = new ListNode(data);

            if(prevNode!=null)
            {
                newItem.next = prevNode.next;
                prevNode.next = newItem;
            }
            else
            {
                Console.WriteLine("The given prevoius node cannot be null");
                return;
            }
        }

        static void Delete(object data)
        {
            if(head == null)
            {
                Console.WriteLine("Cannot delet from an empty linked list.");
                return;
            }
            //to delete head
            if(head.val == data)
            {
                head = head.next;
            }
            else
            {
                ListNode prev = null;
                ListNode current = head;
                while(current.next!= null)
                {
                    if(current.next.val == data)
                    {
                        current.next = current.next.next;
                        return;
                    }
                    prev = current;
                    current = current.next;
                }
                if (current.val == data)
                {
                    prev.next = null;
                }
                else
                    Console.WriteLine("No node found with given key");
            }
        }

        public static void ImplementSingleLinkedList()
        {
            AddLast("one");
            AddLast("two");
            AddLast("three");
            AddLast("five");
            AddFirst("First");
            Delete("five");
            InsertAfter(new ListNode("one"), "four");
            PrintAll();
        }
    }
}
