using System;
namespace MoveZeroes
{
    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            int idx = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    var temp = nums[idx];
                    nums[idx] = nums[i];
                    nums[i] = temp;

                    ++idx;
                }
            }
        }
    }
}
