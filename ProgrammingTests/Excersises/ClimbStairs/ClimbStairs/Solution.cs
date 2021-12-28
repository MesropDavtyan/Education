using System;
namespace ClimbStairs
{
    public class Solution
    {
        // Dynamic Programming (DP) O(n)
        public int ClimbStairsDP(int n)
        {
            int[] dp = new int[n + 1];

            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                dp[i] += dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        // Dynamic Programming (DP) Bottom Up O(n)
        public int ClimbStairsBottomUp(int n)
        {
            int[] dp = new int[n + 1];

            dp[n] = 1;
            dp[n - 1] = 1;

            for (int i = n - 2; i >= 0; i--)
            {
                dp[i] += dp[i + 1] + dp[i + 2];
            }

            return dp[0];
        }

        // Recursive (O(2^n))
        public int ClimbStairs(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            return ClimbStairs(n - 1) + ClimbStairs(n - 2);
        }
    }
}
