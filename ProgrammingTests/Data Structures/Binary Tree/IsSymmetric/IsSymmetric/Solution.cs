using System;
using System.Collections.Generic;
using System.Linq;

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
        public bool IsSymmetricRecursive(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return Helper(root.left, root.right);
        }

        private bool Helper(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
            {
                return left == right;
            }
            if (left.val != right.val)
            {
                return false;
            }

            return Helper(left.left, right.right) && Helper(left.right, right.left);
        }

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
                TreeNode left = nodes.Dequeue();
                TreeNode right = nodes.Dequeue();

                if (left == null && right == null)
                {
                    continue;
                }
                if (left == null || right == null)
                {
                    return false;
                }
                if (left.val != right.val)
                {
                    return false;
                }

                nodes.Enqueue(left.left);
                nodes.Enqueue(right.right);
                nodes.Enqueue(left.right);
                nodes.Enqueue(right.left);
            }

            return true;
        }
    }
}
