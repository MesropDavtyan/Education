using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddCountCharString
{
    public class Solution
    {
        public string OddCountCharString(int N)
        {
            StringBuilder builder = new StringBuilder();
            if (N % 2 == 0)
            {
                for (int i = 1; i <= N - 1; i++)
                {
                    builder.Append('a');
                }
                builder.Append('b');
            }
            else
            {
                for (int i = 1; i <= N; i++)
                {
                    builder.Append('a');
                }
            }
            return builder.ToString();
        }
    }
}
