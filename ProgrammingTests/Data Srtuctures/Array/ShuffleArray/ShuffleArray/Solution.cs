using System;
using System.Text;

namespace ShuffleArray
{
    public class Solution
    {
        public int[] ShuffleArray(int[] numbers)
        {
            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                int j = random.Next(i, numbers.Length);
                var temp = numbers[i];
                numbers[i] = numbers[j];
                numbers[j] = temp;
            }

            return numbers;
        }

        public string RemoveChar(string text)
        {
            StringBuilder sb = new StringBuilder();
            int charCounter = 0;

            foreach (var character in text)
            {
                if (character == '$' && charCounter == 0)
                {
                    charCounter++;
                    sb.Append(character);
                }
                else if (character != '$')
                {
                    sb.Append(character);
                }
            }

            return sb.ToString();
        }
    }
}
