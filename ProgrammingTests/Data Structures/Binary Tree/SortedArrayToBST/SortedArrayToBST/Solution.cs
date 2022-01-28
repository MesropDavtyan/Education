using System;
namespace SortedArrayToBST
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
        public TreeNode SortedArrayToBSTRecursive(int[] nums)
        {
            return Helper(nums, 0, nums.Length - 1);
        }

        private TreeNode Helper(int[] nums, int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            int mid = (left + right) / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = Helper(nums, left, mid - 1);
            root.right = Helper(nums, mid + 1, right);

            return root;
        }
    }
}
