using System;
namespace MaxSubarray
{
    public class Solution
    {
        public int MaxSubArray(int[] nums)
        {
            int curMaxSum = nums[0];
            int maxSum = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                curMaxSum = Math.Max(curMaxSum + nums[i], nums[i]);
                maxSum = Math.Max(curMaxSum, maxSum);
            }

            return maxSum;
        }
    }
}
