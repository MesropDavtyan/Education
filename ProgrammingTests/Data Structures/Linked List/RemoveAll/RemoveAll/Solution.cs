using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection;
using System.Text;
using RemoveAll;
using static System.Net.Mime.MediaTypeNames;

namespace RemoveAll
{
    public class MyQueue
    {
        private Stack<int> inputStack;
        private Stack<int> outputStack;

        public MyQueue()
        {
            inputStack = new Stack<int>();
            outputStack = new Stack<int>();
        }

        public void Push(int x)
        {
            inputStack.Push(x);
        }

        public int Pop()
        {
            Reverse();
            return outputStack.Pop();
        }

        public int Peek()
        {
            Reverse();
            return outputStack.Peek();
        }

        public bool Empty()
        {
            if (inputStack.Count == 0)
            {
                return outputStack.Count == 0;
            }
            else
            {
                return inputStack.Count == 0;
            }
        }

        private void Reverse()
        {
            if (outputStack.Count == 0)
            {
                while (inputStack.Count > 0)
                {
                    outputStack.Push(inputStack.Pop());
                }
            }
        }
    }


    public class MyStack
    {
        Queue<int> firstQueue;
        Queue<int> secondQueue;

        public MyStack()
        {
            firstQueue = new Queue<int>();
            secondQueue = new Queue<int>();
        }

        public void Push(int x)
        {
            firstQueue.Enqueue(x);
        }

        public int Pop()
        {
            while (firstQueue.Count > 1)
            {
                secondQueue.Enqueue(firstQueue.Dequeue());
            }

            int result = firstQueue.Dequeue();
            SwapQueues();
            return result;
        }

        public int Top()
        {
            while (firstQueue.Count > 1)
            {
                secondQueue.Enqueue(firstQueue.Dequeue());
            }

            int result = firstQueue.Dequeue();
            secondQueue.Enqueue(result);
            SwapQueues();
            return result;
        }

        public bool Empty()
        {
            return firstQueue.Count == 0;
        }

        private void SwapQueues()
        {
            Queue<int> temp = firstQueue;
            firstQueue = secondQueue;
            secondQueue = temp;
        }
    }



    public class CustomComparer : IComparer<int>
    {
        public int Compare(int current, int next)
        {
            if (current < next)
            {
                return 1; // swap current and next
            }
            if (current > next)
            {
                return -1; // don't swap
            }
            else
            {
                return 0; // retain (current == next)
            }
        }
    }

 
    //public class ListNode {
    //    public int val;
    //    public ListNode next;
    //    public ListNode(int x) { val = x; }
    //}

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


    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
 

    //------------------------------------------------------------------------------------------------------------------------

    public class LinkNode
    {
        public int val;
        public LinkNode next;

        public LinkNode(int val = 0, LinkNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class MyStackLinkedList
    {
        LinkNode head;

        public MyStackLinkedList()
        {
            head = null;
        }

        public void Push(int val)
        {
            head = head == null ? new LinkNode(val) : new LinkNode(val, head);
        }

        public int Pop()
        {
            if (head != null)
            {
                int result = head.val;
                head = head.next;
                return result;
            }
            else
            {
                throw new Exception("The stack is empty");
            }
        }

        public int Pick()
        {
            if (head != null)
            {
                return head.val;
            }
            else
            {
                throw new Exception("The stack is empty");
            }
        }
    }

    public class MyStackArray
    {
        public int top;
        public int maxSize;
        public int[] stackArr;

        public MyStackArray(int size)
        {
            top = -1;
            maxSize = size;
            stackArr = new int[maxSize];
        }

        public void Push(int val)
        {
            if (top < maxSize)
            {
                stackArr[++top] = val;
            }
            else
            {
                Console.WriteLine("The stack is full.");
            }
        }

        public int Pop()
        {
            if (top > -1)
            {
                return stackArr[top--];
            }
            else
            {
                throw new Exception("The stack is empty.");
            }
        }

        public int Pick()
        {
            if (top > -1)
            {
                return stackArr[top];
            }
            else
            {
                throw new Exception("The stack is empty.");
            }
        }
    }

    //------------------------------------------------------------------------------------------------------------------------

    public class Solution
	{
        public void FindDoublesInList(List<int> values)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int> myList = new List<int>();

            foreach (var value in values)
            {
                if (dict.ContainsKey(value))
                {
                    dict[value]++;
                }
                else
                {
                    dict.Add(value, 1);
                }
            }

            foreach (var value in values)
            {
                if (dict.ContainsKey(value * 2) && dict[value * 2] == 1)
                {
                    myList.Add(value);
                }
            }

            myList.Sort();

            Console.WriteLine(String.Join(' ', myList));
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void PrintClassification(List<List<int>> rawData)
        {
            Dictionary<int, int> points = new Dictionary<int, int>{ { 1, 10 }, { 2, 6 }, { 3, 4 }, { 4, 3 }, { 5, 2 }, { 6, 1 } };
            Dictionary<int, int> winners = new Dictionary<int, int>();

            foreach (var item in rawData)
            {
                int racerName = item[1];
                int position = item[2];

                if(winners.ContainsKey(racerName)){
                    if (points.ContainsKey(position))
                    {
                        winners[racerName] += points[position];
                    }
                }
                else
                {
                    if (points.ContainsKey(position))
                    {
                        winners.Add(racerName, points[position]);
                    }
                }
            }

            int maxPoint = 0;
            int lowestRecordNumber = int.MaxValue;
            KeyValuePair<int, int> winner = new KeyValuePair<int, int>();

            foreach (var win in winners)
            {
                if (win.Value > maxPoint || win.Value == maxPoint && win.Key < lowestRecordNumber)
                {
                    winner = win;
                    maxPoint = win.Value;
                    lowestRecordNumber = win.Key;
                }
            }

            Console.WriteLine($"{winner.Key} {winner.Value}");
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int CountPairs(List<int> array, int diff)
        {
            int pairs = 0;
            int len = array.Count;
            int i = 0;
            int j = 0;

            //array = array.OrderByDescending(i => i).ToList();
            array.Sort(new CustomComparer());

            while (j < len - 1)
            {
                for (i = j + 1;  i < len; ++i)
                {
                    if (array[j] == array[i] + diff)
                    {
                        pairs++;
                    }
                }
                j++;
            }

            return pairs;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int MaxRepeated(string short_s, string long_s)
        {
            if (string.IsNullOrEmpty(short_s) || string.IsNullOrEmpty(long_s))
            {
                return 0;
            }

            int maxCount = 0;
            int count = 0;
            int j = 0;
            for (int i = 0; i < long_s.Length; i++)
            {
                if (long_s[i] == short_s[j])
                {
                    j++;
                    if (j == short_s.Length)
                    {
                        count++;
                        j = 0;
                    }
                }
                else
                {
                    maxCount = Math.Max(maxCount, count);
                    count = 0;
                    j = 0;
                }
            }

            return Math.Max(maxCount, count);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool IsPalindrom(int number)
        {
            int reverseNumber = 0;
            int copyNumber = number;

            while (copyNumber != 0)
            {
                reverseNumber *= 10;
                reverseNumber += copyNumber % 10;
                copyNumber /= 10;
            }

            if (reverseNumber == number)
            {
                return true;
            }

            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool IsPalindromText(string text)
        {
            List<char> letters = new List<char>();
            foreach (char letter in text.ToLower())
            {
                if (char.IsLetterOrDigit(letter))
                {
                    letters.Add(letter);
                }
            }

            for (int i = 0; i < letters.Count; i++)
            {
                if (i != letters.Count / 2)
                {
                    if (letters[i] != letters[letters.Count - 1 - i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int SingleNumber(int[] nums)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (numbers.ContainsKey(num))
                {
                    numbers[num]++;
                }
                else
                {
                    numbers.Add(num, 1);
                }
            }

            foreach (var number in numbers)
            {
                if (number.Value == 1)
                {
                    return number.Key;
                }
            }

            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        //public ListNode GetIntersectionNode(ListNode firstHead, ListNode secondHead)
        //{
        //    Dictionary<ListNode, int> dict = new Dictionary<ListNode, int>();

        //    if (firstHead == null || secondHead == null)
        //    {
        //        return null;
        //    }

        //    while (firstHead != null)
        //    {
        //        dict.Add(firstHead, firstHead.val);
        //        firstHead = firstHead.next;
        //    }

        //    while (secondHead != null)
        //    {
        //        if (dict.ContainsKey(secondHead))
        //        {
        //            return secondHead;
        //        }
        //        else
        //        {
        //            secondHead = secondHead.next;
        //        }
        //    }

        //    return null;
        //}

        public ListNode GetIntersectionNode(ListNode firstHead, ListNode secondHead)
        {
            if (firstHead == null || secondHead == null)
            {
                return null;
            }

            ListNode firstCurr = firstHead;
            ListNode secondCurr = secondHead;

            while (firstCurr != secondCurr)
            {
                firstCurr = firstCurr == null ? secondHead : firstCurr.next;
                secondCurr = secondCurr == null ? firstHead : secondCurr.next;
            }

            return firstCurr;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            List<string> common = new List<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int min = int.MaxValue;

            for (int i = 0; i < list1.Length; i++)
            {
                dict.Add(list1[i], i);
            }

            for (int j = 0; j < list2.Length; j++)
            {
                if (dict.ContainsKey(list2[j]))
                {
                    int sum = j + dict[list2[j]];
                    if (sum < min)
                    {
                        common.Clear();
                        common.Add(list2[j]);
                        min = sum;
                    }
                    else if (sum == min)
                    {
                        common.Add(list2[j]);
                    }
                }
            }

            return common.ToArray();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int CountPrefixes(string[] words, string text)
        {
            int count = 0;

            foreach (var word in words)
            {
                if (word.Length <= text.Length)
                {
                    bool isPrefix = true;

                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] != text[i])
                        {
                            isPrefix = false;
                            break;
                        }
                    }

                    if (isPrefix)
                    {
                        count++;
                    }
                }
            }
            
            return count;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool IsHappy(int number)
        {
            HashSet<int> seen = new HashSet<int>();

            while (number != 1 && !seen.Contains(number))
            {
                seen.Add(number);
                number = Helper(number);
            }

            return number == 1;
        }

        private int Helper(int number)
        {
            int tempNum = 0;

            while (number != 0)
            {
                tempNum += (number % 10) * (number % 10);
                number /= 10;
            }

            return tempNum;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = new ListNode();
            ListNode next = new ListNode();

            while (head != null)
            {
                next = head.next;
                head.next = prev;
                prev = head;
                head = next;
            }

            return prev;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool HasCycle(ListNode head)
        {
            Dictionary<ListNode, int> dict = new Dictionary<ListNode, int>();

            if (head == null || head.next == null)
            {
                return false;
            }

            while (head != null)
            {
                if (dict.ContainsKey(head))
                {
                    return true;
                }
                else
                {
                    dict.Add(head, head.val);
                }

                head = head.next;
            }

            return false;
        }

        //We can solve this problem using the Floyd's cycle-finding algorithm, also known as the "tortoise and hare" algorithm.
        //The idea is to have two pointers, one that moves one step at a time and another that moves two steps at a time.
        //If there is a cycle in the linked list, eventually the faster pointer will catch up to the slower pointer, and we can detect the cycle.
        //If there is no cycle, the faster pointer will reach the end of the list and we can return false.

        public bool HasCycleEfficent(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }

            ListNode slow = head;
            ListNode fast = head.next;

            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                {
                    return false;
                }

                slow = slow.next;
                fast = fast.next.next;
            }

            return true;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int FibRecursive(int number)
        {
            if (number == 0 || number == 1)
            {
                return number;
            }

            return FibRecursive(number - 1) + FibRecursive(number - 2);
        }

        public int Fib(int number)
        {
            List<int> sequence = new List<int> { 0, 1 };

            for (int i = 2; i <= number; i++)
            {
                sequence.Add(sequence[i - 1] + sequence[i - 2]);
            }

            return sequence[number];
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool IsSameTree(TreeNode firstRoot, TreeNode secondRoot)
        {
            Queue<TreeNode> nodes = new Queue<TreeNode>();

            nodes.Enqueue(firstRoot);
            nodes.Enqueue(secondRoot);

            while (nodes.Count != 0)
            {
                var first = nodes.Dequeue();
                var second = nodes.Dequeue();

                if (first == null && second == null)
                {
                    continue;
                }

                if (first == null || second == null || first.val != second.val)
                {
                    return false;
                }

                nodes.Enqueue(first.left);
                nodes.Enqueue(second.left);
                nodes.Enqueue(first.right);
                nodes.Enqueue(second.right);
            }

            return true;
        }

        public bool IsSameTreeRecursive(TreeNode firstRoot, TreeNode secondRoot)
        {
            if (firstRoot == null && secondRoot == null)
            {
                return true;
            }

            if (firstRoot == null || secondRoot == null || firstRoot.val != secondRoot.val)
            {
                return false;
            }

            return IsSameTreeRecursive(firstRoot.left, secondRoot.left) && IsSameTreeRecursive(firstRoot.right, secondRoot.right);
        }

            //------------------------------------------------------------------------------------------------------------------------

            public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);
            nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                var first = nodes.Dequeue();
                var second = nodes.Dequeue();

                if (first == null && second == null)
                {
                    continue;
                }

                if (first == null || second == null)
                {
                    return false;
                }

                if (first.val != second.val)
                {
                    return false;
                }

                nodes.Enqueue(first.left);
                nodes.Enqueue(second.right);
                nodes.Enqueue(first.right);
                nodes.Enqueue(second.left);
            }

            return true;
        }

        public bool IsSymmetricRecursive(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return IsSymmetricRecursive(root.left, root.right);
        }


        public bool IsSymmetricRecursive(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
            {
                return left == right;
            }

            if (left.val != right.val)
            {
                return false;
            }

            return IsSymmetricRecursive(left.left, right.right) && IsSymmetricRecursive(left.right, right.left);
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool IsIsomorphic(string first, string second)
        {
            if (first.Length != second.Length)
            {
                return false;
            }

            Dictionary<char, char> dict = new Dictionary<char, char>();

            for (int i = 0; i < first.Length; i++)
            {
                if (dict.ContainsKey(first[i]))
                {
                    if (dict[first[i]] == second[i])
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (dict.ContainsValue(second[i]))
                    {
                        return false;
                    }
                    else
                    {
                        dict.Add(first[i], second[i]);
                    }
                }
            }

            return true;
        }

        public bool IsIsomorphicEfficent(string first, string second)
        {
            if (first.Length != second.Length)
            {
                return false;
            }

            Dictionary<char, char> firstDict = new Dictionary<char, char>();
            Dictionary<char, char> secondDict = new Dictionary<char, char>();


            for (int i = 0; i < first.Length; i++)
            {
                if (!firstDict.ContainsKey(first[i]) && !secondDict.ContainsKey(second[i]))
                {
                    firstDict[first[i]] = second[i];
                    secondDict[second[i]] = first[i];
                }
                else if (firstDict.ContainsKey(first[i]) && secondDict.ContainsKey(second[i]))
                {
                    if (firstDict[first[i]] != second[i] || secondDict[second[i]] != first[i])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }

            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                var tempRoot = nodes.Dequeue();

                var temp = tempRoot.left;
                tempRoot.left = tempRoot.right;
                tempRoot.right = temp;

                if (tempRoot.left != null)
                {
                    nodes.Enqueue(tempRoot.left);
                }
                if (tempRoot.right != null)
                {
                    nodes.Enqueue(tempRoot.right);
                }
            }

            return root;
        }

        public TreeNode InvertTreeRecursive(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }

            var temp = root.left;
            root.left = InvertTreeRecursive(root.right);
            root.right = InvertTreeRecursive(temp);

            return root;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public TreeNode MergeTreesRecursive(TreeNode root1, TreeNode root2)
        {
            if (root1 == null)
            {
                return root2;
            }
            if (root2 == null)
            {
                return root1;
            }

            TreeNode node = new TreeNode(root1.val + root2.val);
            node.left = MergeTreesRecursive(root1.left, root2.left);
            node.right = MergeTreesRecursive(root1.right, root2.right);

            return node;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> paths = new List<string>();

            if (root == null)
            {
                return paths;
            }

            FindPath(root, string.Empty, paths);

            return paths;
        }

        public void FindPath(TreeNode node, string path, List<string> paths)
        {
            if (node.left == null && node.right == null)
            {
                paths.Add(path + node.val.ToString());
            }

            if (node.left != null)
            {
                FindPath(node.left, path + node.val + "->", paths);
            }

            if (node.right != null)
            {
                FindPath(node.right, path + node.val + "->", paths);
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int MajorityElement(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    ++dict[nums[i]];
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }

            foreach (var item in dict)
            {
                if (item.Value > nums.Length/2)
                {
                    return item.Key;
                }
            }

            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool IsPalindromeLinkedList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }

            List<int> numbers = new List<int>();

            while (head != null)
            {
                numbers.Add(head.val);
                head = head.next;
            }

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                if (numbers[i] != numbers[numbers.Count - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsPalindromeLinkedListEfficient(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }

            ListNode slow = head;
            ListNode fast = head;

            //find middle of the list (slow)
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            //reverse second half of the list
            ListNode prev = null;
            ListNode next = null;

            while (slow != null)
            {
                next = slow.next;
                slow.next = prev;
                prev = slow;
                slow = next;
            }

            //check palindrome
            ListNode left = head;
            ListNode right = prev;
            while (right != null)
            {
                if (left.val != right.val)
                {
                    return false;
                }
                left = left.next;
                right = right.next;
            }

            return true;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int AddDigits(int num)
        {
            int number = AddDigitsHelper(num);

            while (number > 9)
            {
                number = AddDigitsHelper(number);
            }

            return number;
        }

        public int AddDigitsHelper(int number)
        {
            int temp = 0;

            while (number != 0)
            {
                temp += number % 10;
                number = number / 10;
            }

            return temp;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool IsPowerOfThree(int number)
        {
            if (number <= 0)
            {
                return false;
            }

            while (number % 3 == 0)
            {
                number /= 3;
            }

            return number == 1;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool IsUgly(int number)
        {
            if (number <= 0)
            {
                return false;
            }

            int[] primeFactors = new int[] { 2, 3, 5 };

            foreach (var primeFactor in primeFactors)
            {
                if (number % primeFactor == 0)
                {
                    number /= primeFactor;
                }
            }

            return number == 1;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]] -= i;
                    if (Math.Abs(dict[nums[i]]) <= k)
                    {
                        return true;
                    }
                    else
                    {
                        dict[nums[i]] = i;
                    }
                }
                else
                {
                    dict.Add(nums[i], i);
                }
            }

            return false;
        }

        public bool ContainsNearbyDuplicateOptimal(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]) && i - dict[nums[i]] <= k)
                {
                    return true;
                }
                else
                {
                    dict[nums[i]] = i;
                }
            }

            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> ranges = new List<string>();
            Dictionary<int, int[]> dict = new Dictionary<int, int[]>();
            int key = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    dict[key] = new int[2] { nums[i], 0 };
                    continue;
                }

                if (dict.ContainsKey(key) && nums[i] - nums[i - 1] == 1)
                {
                    dict[key][1] = nums[i];
                }
                else
                {
                    ++key;
                    dict[key] = new int[2] { nums[i], 0 };
                }
            }

            foreach (var range in dict)
            {
                if (range.Value[1] == 0)
                {
                    ranges.Add($"{range.Value[0]}");
                }
                else
                {
                    ranges.Add($"{range.Value[0]}->{range.Value[1]}");
                }
            }

            return ranges;
        }

        public IList<string> SummaryRangesOptimal(int[] nums)
        {
            List<string> ranges = new List<string>();
            StringBuilder range = new StringBuilder();
            int iterations = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i + 1 < nums.Length && nums[i + 1] == nums[i] + 1)
                {
                    if (range.Length == 0)
                    {
                        range.Append(nums[i]);
                    }
                    iterations++;
                }
                else
                {
                    if (iterations > 0)
                    {
                        range.Append($"->{nums[i]}");
                        iterations = 0;
                    }
                    else
                    {
                        range.Append(nums[i]);
                    }
                    ranges.Add(range.ToString());
                    range = new StringBuilder();
                }
            }

            return ranges;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool WordPattern(string pattern, string s)
        {
            Dictionary<char, string> dict = new Dictionary<char, string>();
            HashSet<char> letters = new HashSet<char>();
            HashSet<string> textSet = new HashSet<string>();
            string[] texts = s.Split(" ");

            if (pattern.Length != texts.Length)
            {
                return false;
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                letters.Add(pattern[i]);
                textSet.Add(texts[i]);

                if (dict.ContainsKey(pattern[i]))
                {
                    if (dict[pattern[i]] != texts[i])
                    {
                        return false;
                    }
                }
                else
                {
                    dict.Add(pattern[i], texts[i]);
                }
            }

            return letters.Count == textSet.Count;
        }

        public bool WordPatternEfficient(string pattern, string s)
        {
            string[] words = s.Split(' ');
            if (words.Length != pattern.Length)
            {
                return false;
            }

            Dictionary<char, string> dict = new Dictionary<char, string>();
            HashSet<string> used = new HashSet<string>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (!dict.ContainsKey(pattern[i]))
                {
                    if (used.Contains(words[i]))
                    {
                        return false;
                    }
                    dict[pattern[i]] = words[i];
                    used.Add(words[i]);
                }
                else
                {
                    if (dict[pattern[i]] != words[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string ReverseVowels(string s)
        {
            HashSet<char> vowles = new() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            char[] chars = s.ToCharArray();
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                while (left < right && !vowles.Contains(s[left]))
                {
                    left++;
                }

                while (left < right && !vowles.Contains(s[right]))
                {
                    right--;
                }

                char temp = chars[left];
                chars[left] = chars[right];
                chars[right] = temp;

                left++;
                right--;
            }

            return new string(chars);
        }
    }
}

