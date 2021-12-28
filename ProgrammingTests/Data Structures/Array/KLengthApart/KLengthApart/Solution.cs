using System;
namespace KLengthApart
{
    public class Solution
    {
        public bool KLengthApart(int[] nums, int k)
        {
            int idxOfOne = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1 && idxOfOne == -1)
                {
                    idxOfOne = i;
                }
                else if (nums[i] == 1)
                {
                    int interval = i - idxOfOne - 1;
                    if (interval < k)
                    {
                        return false;
                    }
                    idxOfOne = i;
                }
            }

            return true;
        }
    }
}
