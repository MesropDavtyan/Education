using System;

namespace MinDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeNode root = new TreeNode(3, new TreeNode(9), new TreeNode(20, new TreeNode(15), new TreeNode(7))); // 2
            //TreeNode root = new TreeNode(2, null, new TreeNode(3, null, new TreeNode(4, null, new TreeNode(5, null, new TreeNode(6))))); // 5
            //TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3)); // 2
            TreeNode root = new TreeNode(1, new TreeNode(2, new TreeNode(4), null), new TreeNode(3, null, new TreeNode(5))); // 2

            Solution solutionl = new Solution();
            Console.WriteLine(solutionl.MinDepth(root));
        }
    }
}
