using Common;
using System;

namespace AddTwoLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ListNode(7);
            a.next = new ListNode(3);
            a.next.next = new ListNode(8);

            var b = new ListNode(6);
            b.next = new ListNode(9);
            b.next.next = new ListNode(7);

            var result = new Solution().AddTwoNumbers(a, b);
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            int multiplier = 10;
            ListNode result = new ListNode(0);
            ListNode tempNode = result;
            while (true)
            {
                int v1 = 0;
                int v2 = 0;

                if (l1 != null)
                    v1 = l1.val;
                if (l2 != null)
                    v2 = l2.val;

                int temp = v1 + v2 + carry;
                carry = 0;
                if (temp >= multiplier)
                    carry = 1;

                tempNode.next = new ListNode(temp % 10);
                tempNode = tempNode.next;
                l1 = l1 != null ? l1.next : null;
                l2 = l2 != null ? l2.next : null;

                if (l1 == null && l2 == null)
                    break;
            }
            return result.next;
        }
    }
}
