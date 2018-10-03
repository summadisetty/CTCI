using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LinkedList
{
    public class ReturnKthElement
    {
        //Time: O(N)
        static object ReturnKthElementFromLast(ListNode head,int k)
        {
            ListNode current = head;
            int iLength = 0;

            while(current != null)
            {
                iLength++;
                current = current.next;
            }

            if (k > iLength) return 0;

            current = head;
            for(int i=1;i<iLength-k+1;i++)
            {
                current = current.next;
            }
            return current.val;
        }

        //Time: O(N) 
        //place two pointers K nodes apart
        static object ReturnKthElementItertively(ListNode head, int k)
        {
            ListNode slow = head, fast = head;

            for(int i=0;i<k;i++)
            {
                fast = fast.next;
            }
            while(fast !=null)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow.val;
        }

        static void ReturnKthElementFromLast()
        {
            ListNode node = new ListNode(1);
            Console.WriteLine(ReturnKthElementFromLast(node, 4));
        }
    }
}
