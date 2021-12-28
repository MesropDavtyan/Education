using System;
using System.Collections.Generic;

namespace MergeTwoSortedLists
{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
     }

    public class Solution
    {
        public ListNode MergeTwoLists(ListNode first, ListNode second)
        {
            ListNode current = new ListNode(0);
            ListNode temp = current;

            while (first != null && second != null)
            {
                if (first.val < second.val)
                {
                    current.next = first;
                    first = first.next;
                }
                else
                {
                    current.next = second;
                    second = second.next;
                }

                current = current.next;
            }

            if (first != null)
            {
                current.next = first;
                first = first.next;
            }

            if (second != null)
            {
                current.next = second;
                second = second.next;
            }

            return temp.next;
        }
    }
}
