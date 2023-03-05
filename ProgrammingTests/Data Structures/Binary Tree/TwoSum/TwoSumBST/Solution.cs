namespace TwoSumBST
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
        private List<int> TreeToList(TreeNode root)
        {
            List<int> ints = new List<int>();

            if (root != null)
            {
                ints.Add(root.val);
                TreeToList(root.left);
                TreeToList(root.right);
            }

            return ints;
        }

        public bool FindTarget(TreeNode root, int k)
        {
            Dictionary<int, int> intsDict = new Dictionary<int, int>();
            List<int> nums = TreeToList(root);

            for (int i = 0; i < nums.Count; i++)
            {
                if (!intsDict.TryGetValue(nums[i], out _))
                {
                    intsDict.Add(nums[i], i);
                }
            }

            for (int i = 0; i <= nums.Count - 1; i++)
            {
                int number = k - nums[i];

                if (intsDict.TryGetValue(number, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}

