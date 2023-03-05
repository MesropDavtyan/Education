using System;
using System.Collections.Generic;

namespace RemoveElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var myLinkedList = new ListNode(1,
                new ListNode(2,
                new ListNode(6,
                new ListNode(3,
                new ListNode(4,
                new ListNode(5,
                new ListNode(6)))))));

            var result = solution.RemoveElements(myLinkedList, 6);

            while (result != null)
            {
                Console.WriteLine(result.val);
                result = result.next;
            }
        }
    }
}



