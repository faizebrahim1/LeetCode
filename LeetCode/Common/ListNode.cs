using System;

namespace Common
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public ListNode(int[] ints)
        {
            this.val = ints[0];
            ListNode lRef = this;
            for (int i = 1; i < ints.Length; i++)
            {
                lRef.next = new ListNode(ints[i]);
                lRef = lRef.next;
            }
            
        }
    }
}
