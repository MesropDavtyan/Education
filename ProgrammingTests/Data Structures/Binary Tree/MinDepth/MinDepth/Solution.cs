﻿using System;

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
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null)
            {
                return MinDepth(root.right) + 1;
            }
            if (root.right == null)
            {
                return MinDepth(root.left) + 1;
            }
            return 1 + Math.Min(MinDepth(root.right), MinDepth(root.left));
        }
    }
}
