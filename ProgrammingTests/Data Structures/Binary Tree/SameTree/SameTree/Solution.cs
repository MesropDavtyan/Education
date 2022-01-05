using System;
using System.Collections.Generic;

namespace SameTree
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

            return IsSameTree(firstRoot.left, secondRoot.left) && IsSameTree(firstRoot.right, secondRoot.right);
        }

        public bool IsSameTree(TreeNode firstRoot, TreeNode secondRoot)
        {
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(firstRoot);
            nodes.Enqueue(secondRoot);

            while (nodes.Count != 0)
            {
                TreeNode first = nodes.Dequeue();
                TreeNode second = nodes.Dequeue();

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
    }
}
