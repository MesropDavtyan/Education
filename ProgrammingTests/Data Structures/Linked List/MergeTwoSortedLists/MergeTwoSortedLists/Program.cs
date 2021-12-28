using System;

namespace MergeTwoSortedLists
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            ListNode firstHead = new ListNode(1);
            firstHead.next = new ListNode(2);
            firstHead.next.next = new ListNode(4);
            firstHead.next.next.next = new ListNode(85);

            ListNode secondHead = new ListNode(1);
            secondHead.next = new ListNode(3);
            secondHead.next.next = new ListNode(4);

            var result = solution.MergeTwoLists(firstHead, secondHead);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
        }
    }
}
