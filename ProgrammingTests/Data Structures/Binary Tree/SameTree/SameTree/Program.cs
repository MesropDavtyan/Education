using System;

namespace SameTree
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            TreeNode first = new TreeNode(0, new TreeNode(2, new TreeNode(1, new TreeNode(5), new TreeNode(1)), null), new TreeNode(1, new TreeNode(3, null, new TreeNode(6)), new TreeNode(-1, null, new TreeNode(8))));
            TreeNode second = new TreeNode(1, new TreeNode(2, new TreeNode(1, new TreeNode(5), new TreeNode(1)), null), new TreeNode(1, new TreeNode(3, null, new TreeNode(6)), new TreeNode(-1, null, new TreeNode(8))));

            Console.WriteLine(solution.IsSameTree(first, second));
        }
    }
}
