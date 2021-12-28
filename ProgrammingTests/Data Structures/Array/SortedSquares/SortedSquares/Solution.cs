using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedSquares
{
    public class Solution
    {
        public int[] SortedSquares(int[] nums)
        {
            int pointer = nums.Length - 1;
            int last = nums.Length - 1;
            int first = 0;
            int[] result = new int[nums.Length];

            while (first <= last)
            {
                if (nums[first] * nums[first] > nums[last] * nums[last])
                {
                    result[pointer] = nums[first] * nums[first];
                    first++;
                }
                else
                {
                    result[pointer] = nums[last] * nums[last];
                    last--;
                }

                pointer--;
            }

            return result;
        }
    }
}
