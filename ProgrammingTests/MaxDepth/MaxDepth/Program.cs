using System;

namespace MaxDepth
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(0, new TreeNode(2, new TreeNode(1, new TreeNode(5), new TreeNode(1)), null), new TreeNode(1, new TreeNode(3, null, new TreeNode(6)), new TreeNode(-1, null, new TreeNode(8))));

            Solution solutionl = new Solution();
            Console.WriteLine(solutionl.MaxDepth(root));
        }
    }
}
