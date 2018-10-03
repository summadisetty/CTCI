using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    public class Palindrome
    {
        static ListNode head;
        

        //split the linked lits in middle
        //if odd, ignore the middle
        //save the first split to stack
        //compare stack elements to remaining split
        static bool IsPalindromeUsingStack(ListNode node)
        {
            ListNode fast = node, slow = node;
            Stack<int> stack = new Stack<int>();

            while(fast!=null && fast.next!=null)
            {
                stack.Push((int)slow.val);
                slow = slow.next;
                fast = fast.next.next;
            }

            //if there are odd number of items in linked list, ignore the middle
            if(fast!=null)
            {
                slow = slow.next;
            }

            while(slow!=null)
            {
                int top = stack.Pop();
                if((int)slow.val != top)
                {
                    return false;
                }
                slow = slow.next;
            }
            return true;
        }

        //reverse the original list and save it to new list
        //compare new list with original list
        static bool IsPalindromeUsingReverse(ListNode node)
        {
            ListNode newItem = null;
            ListNode reverse_head = null;
            ListNode head = node;

            //reverse the original linked list and save it to new list
            while(node!=null)
            {
                newItem = new ListNode(node.val);
                if (reverse_head == null)
                {
                    reverse_head = newItem;
                    reverse_head.next = null;
                }
                else
                {
                    newItem.next = reverse_head;
                    reverse_head = newItem;
                }
                node = node.next;
            }

            //compare lists
            ListNode orig_curr = head;
            ListNode rev_curr = reverse_head;
            while(orig_curr!= null && rev_curr!=null)
            {
                if((int)orig_curr.val != (int)rev_curr.val)
                {
                    return false;
                }
                orig_curr = orig_curr.next;
                rev_curr = rev_curr.next;
            }
            return true;
        }

        /* Push a node to linked list. Note that this function 
       changes the head */
        static void Push(int new_data)
        {
            /* Allocate the Node & 
               Put in the data */
            ListNode new_node = new ListNode(new_data);

            /* link the old list off the new one */
            if(head == null)
            {
                head = new_node;
            }
            else
            {
                new_node.next = head;
                /* Move the head to point to new Node */
                head = new_node;
            }             
        }

        // A utility function to print a given linked list
        static void PrintList(ListNode ptr)
        {
            while (ptr != null)
            {
                Console.Write(ptr.val + "->");
                ptr = ptr.next;
            }
            Console.WriteLine("NULL");
        }

        public static void IsPalindrome()
        {
            int[] str = {1, 2, 1, 8, 1, 2, 1};
            for (int i = 0; i < 7; i++)
            {
                Push(str[i]);
                PrintList(head);
                if (IsPalindromeUsingStack(head) != false)
                {
                    Console.WriteLine("Is Palindrome using Stack");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Not Palindrome using Stack");
                    Console.WriteLine("");
                }
                if (IsPalindromeUsingReverse(head) != false)
                {
                    Console.WriteLine("Is Palindrome using Reverse");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Not Palindrome using Reverse");
                    Console.WriteLine("");
                }
            }            
        }
    }
}
