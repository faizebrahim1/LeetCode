using Common;
using System;

namespace ReverseLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 2, 3, 4 };
            ListNode ln = new ListNode(arr);

            //first get the first node, then isolate it
            //then get second node, isolate it, set second next = first
            //now we have 2, 1
            //the get 3rd node, isolte and repeat

            ListNode refnode = ln;
            ListNode reversed = null;
            while(refnode != null)
            {
                ListNode placeHolder = refnode.next;
                refnode.next = reversed;
                reversed = refnode;
                refnode = placeHolder;
            }

        }
    }
}
