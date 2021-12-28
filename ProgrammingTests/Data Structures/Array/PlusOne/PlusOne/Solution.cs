using System;
using System.Collections.Generic;

namespace PlusOne
{
    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            //if (digits.Length > 0)
            //{
            //    int number = 0;
            //    int multiplyer = 1;

            //    for (int i = digits.Length - 1; i >= 0; i--)
            //    {
            //        number += digits[i] * multiplyer;

            //        multiplyer *= 10;
            //    }

            //    int addedNumber = number + 1;
            //    Stack<int> newDigits = new Stack<int>();

            //    while (addedNumber > 0)
            //    {
            //        newDigits.Push(addedNumber % 10);

            //        addedNumber /= 10;
            //    }

            //    int[] result = new int[newDigits.Count];

            //    for (int i = 0; i < result.Length; i++)
            //    {
            //        result[i] = newDigits.Pop();
            //    }

            //    return result;
            //}

            //if (digits.Length > 0)
            //{
            //    int adder = 1;

            //    for (int i = digits.Length - 1; i >= 0; i--)
            //    {
            //        int digit = digits[i] + 1;
            //        if (digit == 10)
            //        {
            //            digits[i] = 0;
            //        }
            //        else
            //        {
            //            digits[i] = digit;
            //            adder = 0;
            //            break;
            //        }
            //    }

            //    if (adder == 1)
            //    {
            //        int[] result = new int[digits.Length + 1];

            //        result[0] = 1;
            //        for (int i = 0; i < digits.Length; i++)
            //        {
            //            result[i + 1] = digits[i];
            //        }

            //        return result;
            //    }
            //    else
            //    {
            //        return digits;
            //    }
            //}

            if (digits.Length > 0)
            {
                for (int i = digits.Length - 1; i >= 0; i--)
                {
                    if (digits[i] < 9)
                    {
                        digits[i]++;
                        return digits;
                    }

                    digits[i] = 0;
                }

                int[] result = new int[digits.Length + 1];
                result[0] = 1;

                return result;
            }

            return new int[] { };
        }
    }
}
