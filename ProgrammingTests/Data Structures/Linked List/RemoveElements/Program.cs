using System;
using System.Collections.Generic;

namespace RemoveElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            List<ListNode> list = new List<ListNode>();
            list.Add(new ListNode(1));
            list.Add(new ListNode(2));
            list.Add(new ListNode(6));
            list.Add(new ListNode(3));
            list.Add(new ListNode(4));
            list.Add(new ListNode(5));
            list.Add(new ListNode(6));

            foreach (var item in list)
            {
                var result = solution.RemoveElements(item, 6);
                if (result != null)
                {
                    Console.WriteLine(result.val);
                }
            }
        }
    }
}
