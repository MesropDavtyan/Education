using System.Text;
namespace AddBinary
{
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            StringBuilder result = new StringBuilder();
            int carry = 0;
            int i = a.Length - 1;
            int j = b.Length - 1;

            while (i >= 0 || j >= 0)
            {
                int sum = carry;

                if (i >= 0)
                {
                    sum += a[i--] - '0';
                }

                if (j >= 0)
                {
                    sum += b[j--] - '0';
                }

                carry = sum / 2;
                sum = sum % 2;

                result.Insert(0, sum);
            }

            if (carry > 0)
            {
                result.Insert(0, 1);
            }

            return result.ToString();
        }

        public int MySqrt(int x)
        {
            if (x == 0 || x == 1)
            {
                return x;
            }

            long left = 0;
            long right = x;

            while (left <= right)
            {
                long mid = (left + right) / 2;

                if (mid * mid == x)
                {
                    return (int)mid;
                }
                else if (mid * mid > x)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return (int)left - 1;
        }
    }
}
