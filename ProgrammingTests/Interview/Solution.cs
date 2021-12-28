using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Solution
    {
        public int GetAllPossibleTimesCount(int a, int b, int c, int d)
        {
            int[] digits = { a, b, c, d };
            HashSet<int> result = new HashSet<int>();

            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] <= 2)
                {
                    for (int j = 0; j < digits.Length; j++)
                    {
                        if (digits[i] == 1 || digits[j] <= 3)
                        {
                            for (int k = 0; k < digits.Length; k++)
                            {
                                if (digits[k] <= 5)
                                {
                                    for (int l = 0; l < digits.Length; l++)
                                    {
                                        if (i != j && i != k && i != l && j != k && j != l && k != l && digits[l] <= 9)
                                        {
                                            result.Add(digits[i] * 1000 + digits[j] * 100 + digits[k] * 10 + digits[l]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result.Count();
        }
    }
}
