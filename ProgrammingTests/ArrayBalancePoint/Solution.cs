namespace ArrayBalancePoint
{
    public class Solution
    {
        public int BalancePoint(int[] input)
        {
            var leftSum = 0;
            var totalSum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                totalSum += input[i];
            }

            for (int i = 0; i < input.Length; i++)
            {
                totalSum -= input[i];

                if (i > 0 && leftSum == totalSum)
                {
                    return i;
                }

                if (i == input.Length - 1)
                {
                    return -1;
                }

                leftSum += input[i];
            }

            return -1;
        }
    }
}
