using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciSequence
{
    public class Solution
    {
        public int FibonacciNumber(int number)
        {
            if (number == 0)
            {
                return 0;
            }
            if (number == 1 || number == 2)
            {
                return 1;
            }

            return FibonacciNumber(number - 1) + FibonacciNumber(number - 2);
        }
    }
}
