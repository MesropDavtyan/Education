namespace RemoveElements
{
    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            while (head != null && head.val == val)
            {
                head = head.next;
            }

            var currentNode = head;
            while (currentNode != null && currentNode.next != null)
            {
                if (currentNode.next.val == val)
                {
                    currentNode.next = currentNode.next.next;
                }
                else
                {
                    currentNode = currentNode.next;
                }
            }

            return head;
        }
    }
}