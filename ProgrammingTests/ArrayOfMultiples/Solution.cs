using System.Collections.Generic;

namespace ArrayOfMultiples
{
    public class Solution
    {
        public List<int> ArrayOfMultiples(int num, int length)
        {
            var multiples = new List<int>();

            for (int i = 1; i <= length; i++)
            {
                multiples.Add(num * i);
            }

            return multiples;
        }
    }
}
