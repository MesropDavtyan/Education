using System;
using System.Collections.Generic;

namespace MaxDepth
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
        public int MaxDepthRecursive(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            //int leftDepth = MaxDepthRecursive(root.left);
            //int rightDepth = MaxDepthRecursive(root.right);
            //if (leftDepth > rightDepth)
            //{
            //    return 1 + leftDepth;
            //}
            //else
            //{
            //    return 1 + rightDepth;
            //}

            return 1 + Math.Max(MaxDepthRecursive(root.left), MaxDepthRecursive(root.right));
        }

        public int MaxDepthBreadthForSearch(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int level = 0;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int count = queue.Count;

                while (count --> 0)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                level++;

            }

            return level;
        }

        public int MaxDepth(TreeNode root)
        {
            int result = 0;

            Stack<KeyValuePair<TreeNode, int>> stack = new Stack<KeyValuePair<TreeNode, int>>();
            stack.Push(new KeyValuePair<TreeNode, int>(root, 1));

            while (stack.Count != 0)
            {
                KeyValuePair<TreeNode, int> item = stack.Pop();
                TreeNode node = item.Key;
                int depth = item.Value;

                if (node != null)
                {
                    result = Math.Max(result, depth);
                    stack.Push(new KeyValuePair<TreeNode, int>(node.left, depth + 1));
                    stack.Push(new KeyValuePair<TreeNode, int>(node.right, depth + 1));
                }
            }

            return result;
        }
    }
}
