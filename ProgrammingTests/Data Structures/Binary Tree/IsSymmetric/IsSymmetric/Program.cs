using System;

namespace IsSymmetric
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            TreeNode root = new TreeNode(1,
                new TreeNode(2,
                    new TreeNode(4), new TreeNode(3)),
                new TreeNode(2,
                    new TreeNode(3), new TreeNode(3)));

            Console.WriteLine(solution.IsSymmetric(root));
        }
    }
}
