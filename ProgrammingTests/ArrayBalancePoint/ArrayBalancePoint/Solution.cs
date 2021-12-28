using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ArrayBalancePoint
{
    public class Solution
    {
        public int BalancePoint(int[] input)
        {
            var leftSum = 0;
            var totalSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                totalSum += input[i];
            }

            for (int i = 0; i < input.Length; i++)
            {
                totalSum -= input[i];

                if (i > 0 && leftSum == totalSum)
                {
                    return i;
                }

                leftSum += input[i];
            }

            return -1;
        }
    }
}
