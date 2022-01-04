using System;
using System.Collections.Generic;

//Given a binary tree, find its minimum depth.

//The minimum depth is the number of nodes along the shortest path from the root node down to the nearest leaf node.

//Note: A leaf is a node with no children.

//Example:

//Given binary tree[3, 9, 20, null, null, 15, 7],

//    3
//   / \
//  9  20
//    /  \
//   15   7
//return its minimum depth = 2.

namespace MinDepth
{

    // Definition for a binary tree node.
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
        public int MinDepthRecursive(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null)
            {
                return MinDepthRecursive(root.right) + 1;
            }
            if (root.right == null)
            {
                return MinDepthRecursive(root.left) + 1;
            }
            return 1 + Math.Min(MinDepthRecursive(root.right), MinDepthRecursive(root.left));
        }

        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            Queue<TreeNode> nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(root);
            int level = 1;

            while (nodeQueue.Count > 0)
            {
                int count = nodeQueue.Count;

                while (count --> 0)
                {
                    TreeNode node = nodeQueue.Dequeue();
                    if (node.left == null && node.right == null)
                    {
                        return level;
                    }
                    if (node.left != null)
                    {
                        nodeQueue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        nodeQueue.Enqueue(node.right);
                    }
                }

                level++;
            }

            return level;
        }
    }
}
