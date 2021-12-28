using System;
using System.Collections.Generic;

namespace DeleteDuplicates
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var solution = new Solution();

            ListNode head = new ListNode(1, null);
            head.next = new ListNode(2, null);
            head.next.next = new ListNode(2, null);
            head.next.next.next = new ListNode(3, null);
            head.next.next.next.next = new ListNode(4, null);
            head.next.next.next.next.next = new ListNode(4, null);

            ListNode newHead = solution.DeleteDuplicates(head);

            while (newHead != null)
            {
                Console.WriteLine(newHead.val);

                newHead = newHead.next;
            }
        }
    }
}
