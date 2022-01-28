using System;

namespace SortedArrayToBST
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            TreeNode root = solution.SortedArrayToBSTRecursive(new int[] { 0, 1, 2, 3, 4, 5 });

            Console.WriteLine(string.Format("Root Value : {0} \nLeft Node Value : {1} \nRight Node Value : {2}", root.val, root.left.val, root.right.val));
        }
    }
}
