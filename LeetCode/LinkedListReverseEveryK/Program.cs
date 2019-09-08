using Common;
using System;
using System.Collections.Generic;

namespace LinkedListReverseEveryK
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5}; //expected {2, 1, 4, 3, 6, 5} -- for k

            ListNode ln = new ListNode(arr);

            ListNode copy = ln;
            ListNode prev = null;
            ListNode placeholder = null;
            int i = 1;
            Queue<ListNode> q = new Queue<ListNode>();

            while (copy != null)
            {
                placeholder = copy.next;
                copy.next = prev;
                prev = copy;
                if (i % 3 == 0 || placeholder == null)
                {
                    q.Enqueue(prev);
                    prev = null;
                }
                copy = placeholder;
                i++;
            }

            var first = q.Dequeue();
            while (q.Count > 0)
            {
                var curr = q.Dequeue();
                first = GetLastNode(first, curr);
            }
            
        }

        private static ListNode GetLastNode(ListNode head, ListNode next)
        {
            var temp = head;
            while(temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = next;
            return head;
        }
    }
}
