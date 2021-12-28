using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQRT
{
    public class Solution
    {
        public long GetRoot(long number)
        {
            if (number == 0 || number == 1)
            {
                return number;
            }

            long start = 0, end = number;

            while (start <= end)
            {
                long middle = (start + end) / 2;

                if (middle * middle == number)
                {
                    return middle;
                }
                if (middle * middle < number)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return start - 1;
        }

        public long Sqrt(long n)
        {
            long start = 0, end = n / 2, middle = n / 4;
            while (start < end - 1)
            {
                long sqr = middle * middle;
                if (sqr < n)
                {
                    start = middle;
                }
                else if (sqr > n)
                {
                    end = middle;
                }
                else
                {
                    return middle;
                }
                middle = (start + end) / 2;
            }
            return start;
        }
    }
}
