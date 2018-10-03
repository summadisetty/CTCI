using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    public class RemoveDups
    {
        //Time: O(N^2)
        static void RemoveDupWithoutBuffer(ListNode head)
        {
            ListNode current = head;
            ListNode runner = head;
            ListNode prev = null;

            while(current!=null)
            {
                runner = current.next;
                while(runner != null)
                {
                    if (current.val == runner.val)
                    {
                        prev.next = runner.next;
                    }
                    else
                    {
                        prev = runner;
                    }
                    runner = runner.next;
                }
                current = current.next;
            }

        }

        //Time: O(N)
        static void RemoveDupWithBuffer(ListNode head)
        {
            ListNode current = head;
            ListNode prev = null;
            Hashtable ht = new Hashtable();

            while (current != null)
            {
                if(ht.ContainsKey(current.val))
                {
                    prev.next = current.next;
                }
                else
                {
                    ht.Add(current.val, 1);
                    prev = current;
                }
                current = current.next;
            }

        }
    }
}
