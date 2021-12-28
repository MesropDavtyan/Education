using System;
using System.Collections.Generic;

namespace LongestCommonPrefix
{
    public class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            string commonPrefix = string.Empty;
            Dictionary<char, int> characters = new Dictionary<char, int>();

            for (char i = 'a'; i <= 'z'; i++)
            {
                characters.Add(i , 0);
            }

            for (int i = 0; i < strs.Length; i++)
            {
                for (int j = 0; j < strs[i].Length; j++)
                {
                    ++characters[strs[i][j]];
                }
            }

            for (int i = 0; i < strs[0].Length; i++)
            {
                if (characters[strs[0][i]] >= strs.Length)
                {
                    commonPrefix += strs[0][i];
                }
                else
                {
                    break;
                }
            }

            return commonPrefix;
        }
    }
}
