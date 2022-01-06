using System;
namespace IsSymmetric
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public bool isSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return isSymmetric(root.left, root.right);
        }

        public bool isSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
            {
                return left == null;
            }
            if (left.val != right.val)
            {
                return false;
            }

            return isSymmetric(left.left, right.right) && isSymmetric(left.right, right.left);
        }
    }
}
