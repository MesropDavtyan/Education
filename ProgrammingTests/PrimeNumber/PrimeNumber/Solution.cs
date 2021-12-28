using System.Collections.Generic;

namespace PrimeNumber
{
    public class Solution
    {
        public List<int> GetPrimeList(int[] numbers)
        {
            List<int> primeNumbers = new List<int>();

            foreach (var number in numbers)
            {
                if ((number % 2 != 0 || number == 2) && number != 1)
                {
                    primeNumbers.Add(number);
                }
            }

            return primeNumbers;
        }
    }
}
