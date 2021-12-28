using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class Solution3
    {
        public int GetBiggestNumber(int num)
        {
            int result = 0;

            int[] digits = NumberToArray(Math.Abs(num));

            int i = 0;
            int coff = 1;

            if (num < 0)
            {
                coff = -1;
                i = digits.Length - 1;
            }
            while ((i < digits.Length && i >= 0) && digits[i] > 5)
            {
                i += coff;
            }
            i = Math.Max(i, 0);
            i = Math.Min(i, digits.Length - 1);

            for (int j = 0; j < digits.Length; j++)
            {
                if (i == j)
                {
                    if (coff > 0)
                    {
                        result = result * 10 + Math.Max(5, digits[j]);
                        result = result * 10 + Math.Min(5, digits[j]);
                    }
                    else
                    {
                        result = result * 10 + Math.Min(5, digits[j]);
                        result = result * 10 + Math.Max(5, digits[j]);
                    }
                }
                else
                {
                    result = result * 10 + digits[j];
                }

            }

            return result * coff;
        }

        public int[] NumberToArray(int num)
        {
            var number = num;
            var length = 0;

            if (num == 0)
            {
                return new int[] { num };
            }

            while (number > 0)
            {
                length++;
                number /= 10;
            }

            int[] arr = new int[length];

            while (num > 0)
            {
                for (int i = length - 1; i >= 0; i--)
                {
                    arr[i] = num % 10;
                    num /= 10;
                }
            }

            return arr;
        }
    }
}
