using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tvaca mi hat Integer N,
// petqa gres funkcia vor@ kveradarcni et tvi tvanshannerov sarqac amenamec tive,
// ete et tiv@  100 000 000 ic meca return es anum -1

namespace BiggestNumber
{
    public class Solution
    {
        // complexity N(LogN)
        public int BiggestNumberInefficient(int num)
        {
            StringBuilder number = new StringBuilder();

            char[] numArr = num.ToString().ToCharArray();
            Array.Sort(numArr);

            for (int i = numArr.Length - 1; i >= 0; i--)
            {
                number.Append(numArr[i]);
            }

            try
            {
                int result = Convert.ToInt32(number.ToString());

                if (result <= 100000000)
                {
                    return result;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // complexity O(N)
        public int[] NumberToArray(int num)
        {
            var number = num;
            var length = 0;

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

        public int BiggestNumber(int num)
        {
            int[] count = new int[10];
            int[] digits = NumberToArray(num);
            int result = 0;
            int multiplier = 1;

            for (int i = 0; i < digits.Length; i++)
            {
                count[digits[i]]++;
            }

            for (int i = 0; i <= 9; i++)
            {
                while (count[i] > 0)
                {
                    result += i * multiplier;
                    count[i]--;
                    multiplier *= 10;
                }
            }

            return result > 100000000 ? -1 : result;
        }

        // complexity O(N) best option
        public int GetBiggestNumber(int num)
        {
            int multiplyer = 1;
            int[] digits = new int[10];
            while (num > 0)
            {
                digits[num % 10]++;
                num = num / 10;
                multiplyer *= 10;
            }

            int result = 0;
            for (int i = 9; i >= 0; i--)
            {
                while (digits[i] > 0)
                {
                    multiplyer /= 10;
                    result += i * multiplyer;
                    digits[i]--;
                }
            }
            return result > 100000000 ? -1 : result;
        }
    }
}
