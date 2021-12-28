using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExceptSelf
{
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var length = nums.Length;

            var leftProducts = new int[length];
            var rightProducts = new int[length];

            var products = new int[length];

            leftProducts[0] = 1;
            rightProducts[length - 1] = 1;

            for (int i = 1; i < length; i++)
            {
                leftProducts[i] = nums[i - 1] * leftProducts[i - 1];
            }

            for (int i = length-2; i >= 0; i--)
            {
                rightProducts[i] = nums[i + 1] * rightProducts[i + 1];
            }

            for (int i = 0; i < length; i++)
            {
                products[i] = rightProducts[i] * leftProducts[i];
            }

            return products;
        }
    }
}
