using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInsert
{
    class Solution
    {
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (right + left) / 2;

                if (target > nums[mid])
                {
                    left = mid + 1;
                }
                else if (target < nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            return left;
        }
    }
}
