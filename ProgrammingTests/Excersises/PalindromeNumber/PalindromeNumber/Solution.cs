using System;
using System.Collections.Generic;

namespace PalindromeNumber
{
    public class Solution
    {
        public bool IsPalindrome(int number)
        {
            long reversedNumber = 0;
            int copyOfNumber = number;

            while (copyOfNumber > 0)
            {
                reversedNumber *= 10;
                reversedNumber += copyOfNumber % 10;
                copyOfNumber /= 10;
            }

            return number == reversedNumber;
        }
    }
}
