using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
   public class SumListForward
    {
        static ListNode head1, head2, result;
        static int carry;
        static ListNode cur; 

        /* A utility function to push a value to linked list */
        static void Push(int val, int list)
        {
            ListNode newnode = new ListNode(val);
            if (list == 1)
            {
                newnode.next = head1;
                head1 = newnode;
            }
            else if (list == 2)
            {
                newnode.next = head2;
                head2 = newnode;
            }
            else
            {
                newnode.next = result;
                result = newnode;
            }

        }

        static int GetSize(ListNode head)
        {
            int count = 0;
            while (head != null)
            {
                count++;
                head = head.next;
            }
            return count;
        }

        // Adds two linked lists of same size represented by 
        // head1 and head2 and returns head of the resultant  
        // linked list. Carry is propagated while returning  
        // from the recursion 
        static void AddSameSize(ListNode n, ListNode m)
        {
            // Since the function assumes linked lists are of  
            // same size, check any of the two head pointers 
            if (n == null)
                return;

            // Recursively add remaining nodes and get the carry 
            AddSameSize(n.next, m.next);

            // add digits of current nodes and propagated carry 
            int sum = (int)n.val + (int)m.val + carry;
            carry = sum / 10;
            int value = sum % 10;

            // Push this to result list 
            Push(value, 3);

        }

        // to pad '0's to the left of the list. 
        static ListNode PadList(ListNode head, int padding)
        {
            ListNode newItem = new ListNode(0);
            for(int i=0;i<padding;i++)
            {
                newItem.next = head;
                head = newItem;
            }
            return head;
        } 


        // The main function that adds two linked lists  
        // represented by head1 and head2. The sum of two  
        // lists is stored in a list referred by result 
        static void Addlists()
        {
            // first list is empty 
            if (head1 == null)
            {
                result = head2;
                return;
            }

            // first list is empty 
            if (head2 == null)
            {
                result = head1;
                return;
            }

            int size1 = GetSize(head1);
            int size2 = GetSize(head2);

            // Add same size lists 
            if (size1 == size2)
            {
                AddSameSize(head1, head2);
            }
            else
            {
                //bring both lists to same size
                if (size1 > size2)
                {
                    head2 = PadList(head2, size1 - size2);
                }
                else
                {
                    head1 = PadList(head1, size2 - size1);
                }

                // get addition of same size lists 
                AddSameSize(head1, head2);
            }
            // if some carry is still there, add a new node to  
            // the front of the result list. e.g. 999 and 87 
            if (carry > 0)
                Push(carry, 3);

        }

        // Function to print linked list 
        static void Printlist(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val + " ");
                head = head.next;
            }
        }


        public static void SumList()
        {
            head1 = null;
            head2 = null;
            result = null;
            carry = 0;
            int[] arr1 = { 9, 9, 9 };
            int[] arr2 = { 1, 8 };

            // Create first list as 9->9->9 
            for (int i = arr1.Length - 1; i >= 0; --i)
                Push(arr1[i], 1);

            // Create second list as 1->8 
            for (int i = arr2.Length - 1; i >= 0; --i)
                Push(arr2[i], 2);

            Addlists();

            Printlist(result);
        }
    }
}
