using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class Solution
    {
        public void SortOptimal(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        var temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
        }

        public void Sort(int[] numbers)
        {
            bool isSorted = false;
            int lastIndex = numbers.Length - 1;

            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < lastIndex; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        Swap(numbers, i, i + 1);
                        isSorted = false;
                    }
                }
                lastIndex--;
            }
        }

        public void Swap(int[] numbers, int i, int j)
        {
            var temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }
}
