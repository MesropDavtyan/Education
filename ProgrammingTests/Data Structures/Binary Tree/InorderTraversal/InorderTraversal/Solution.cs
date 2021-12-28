using System.Collections.Generic;

namespace InorderTraversal
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public class Solution
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            List<int> result = new List<int>();

            while (nodeStack.Count != 0 || root != null)
            {
                while (root != null)
                {
                    nodeStack.Push(root);
                    root = root.left;
                }

                root = nodeStack.Pop();
                result.Add(root.val);
                root = root.right;
            }

            return result;
        }
    }
}
