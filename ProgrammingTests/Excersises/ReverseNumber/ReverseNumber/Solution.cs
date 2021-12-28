using System;
namespace ReverseNumber
{
    public class Solution
    {
        public int ReverseNumber(int number)
        {
            long reversedNumber = 0;
            bool isNegative = false;

            if (number < 0)
            {
                number = -number;
                isNegative = true;
            }

            while (number > 0)
            {
                reversedNumber *= 10;
                reversedNumber += number % 10;
                number /= 10;
            }

            if (reversedNumber <= int.MinValue || reversedNumber >= int.MaxValue)
            {
                return 0;
            }

            return (int)(isNegative ? 0 -reversedNumber : reversedNumber);
        }
    }
}
