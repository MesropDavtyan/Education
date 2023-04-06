using RemoveAll;

Solution solution = new Solution();
List<int> values = new List<int> { 1,2,3,4,5,6,7,8,9,0,8 };
////List<int> values = new List<int> { 1,1,2 };


//solution.FindDoublesInList(values);


List<List<int>> rawData = new List<List<int>>
{
    new List<int>{ 2001, 1004, 1 },
    new List<int>{ 2002, 1003, 1 },
    new List<int>{ 2001, 1003, 2 },
    new List<int>{ 2002, 1004, 2 },
    new List<int>{ 2001, 1001, 3 },
    new List<int>{ 2002, 1001, 3 },
    new List<int>{ 2001, 1002, 4 },
    new List<int>{ 2002, 1002, 4 },
};

//solution.PrintClassification(rawData);

List<int> test = new List<int> { 1,3,2,5,4 };
//solution.CountPairs(test, 2); //3

//solution.IsPalindrom(12321);
//solution.IsPalindromText("A man, a plan, a canal: Panama");
//solution.IsPalindromText("0p");

//ListNode theNode = new ListNode(8);
//theNode.next = new ListNode(4);
//theNode.next.next = new ListNode(5);

//ListNode firstHead = new ListNode(4);
//firstHead.next = new ListNode(1);
//firstHead.next.next = theNode;

//ListNode secondHead = new ListNode(5);
//secondHead.next = new ListNode(6);
//secondHead.next.next = new ListNode(1);
//secondHead.next.next.next = theNode;

//solution.GetIntersectionNode(firstHead, secondHead);

//string[] list1 = new string[] { "happy", "sad", "good" };
//string[] list2 = new string[] { "sad", "happy", "good" };

//solution.FindRestaurant(list1, list2);

//string[] words = new string[] { "a", "b", "c", "ab", "bc", "abc" };
//string text = "abc";

//solution.CountPrefixes(words, text);

//solution.IsHappy(2);

//solution.MaxRepeated("AB", "ABCABCABABABC");

//MyStack stack = new MyStack();

//stack.Push(1);
//stack.Push(2);
//stack.Push(3);

//Console.WriteLine($"Popped value: {stack.Pop()}");
//Console.WriteLine($"Picked value: {stack.Pick()}");

//MyStack2 stack2 = new MyStack2(4);

//stack2.Push(1);
//stack2.Push(2);
//stack2.Push(3);

//Console.WriteLine($"Popped value: {stack2.Pop()}");
//Console.WriteLine($"Picked value: {stack2.Pick()}");

//ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
//solution.ReverseList(head);

//ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
//head.next.next.next.next = head.next;

//bool isCycle = solution.HasCycle(head);

//Console.WriteLine(isCycle);

//Console.WriteLine(solution.Fib(3));
//Console.WriteLine(solution.FibRecursive(3));

//TreeNode root = new TreeNode(4, new TreeNode(2, new TreeNode(1), new TreeNode(3)), new TreeNode(7, new TreeNode(6), new TreeNode(9)));
//solution.InvertTree(root);

//TreeNode root1 = new TreeNode(1, new TreeNode(3, new TreeNode(5)), new TreeNode(2));
//TreeNode root2 = new TreeNode(2, new TreeNode(1, null, new TreeNode(4)), new TreeNode(3, null, new TreeNode(7)));

//solution.MergeTreesRecursive(root1, root2);

//var stack = new MyStack();
//stack.Push(1);
//stack.Push(2);
//var a = stack.Top();
//var b = stack.Pop();
//var c = stack.Empty();

//stack.Push(1);
//stack.Push(2);
//var aa = stack.Pop();
//var bb = stack.Top();

//stack.Push(1);
//var aaa = stack.Top();

//solution.AddDigits(138);

solution.SummaryRangesOptimal(new int[] { 0, 1, 2, 4, 5, 7, 9, 10 });
