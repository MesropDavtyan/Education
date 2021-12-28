using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePaths
{
    public class Solution
    {
        // DP Buttom Up
        public int UniquePathsDPButtomUp(int m, int n)
        {
            int[,] dp = new int[m, n];

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (i == m - 1 || j == n - 1)
                    {
                        dp[i, j] = 1;
                    }
                    else
                    {
                        dp[i, j] = dp[i + 1, j] + dp[i, j + 1];
                    }
                }
            }

            return dp[0, 0];
        }

        // DP
        public int UniquePathsDP(int m, int n)
        {
            int[,] dp = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 1;
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
            }

            return dp[m - 1, n - 1];
        }

        // Recursion
        public int UniquePathsRec(int m, int n)
        {
            if (m < 1 || n < 1)
            {
                return 0;
            }

            if (m == 1 && n == 1)
            {
                return 1;
            }

            return UniquePathsRec(m - 1, n) + UniquePathsRec(m, n - 1);
        }

        // Recursion with memoazation
        public int Helper(int m, int n, int[,] memo)
        {
            if (m < 1 || n < 1)
            {
                return 0;
            }

            if (m == 1 && n == 1)
            {
                return 1;
            }

            if (memo[m,n] != 0)
            {
                return memo[m, n];
            }

            memo[m, n] = Helper(m - 1, n, memo) + Helper(m, n - 1, memo);
            return memo[m, n];
        }

        public int UniquePaths(int m, int n)
        {
            return Helper(m, n, new int[m + 1, n + 1]);
        }
    }
}
