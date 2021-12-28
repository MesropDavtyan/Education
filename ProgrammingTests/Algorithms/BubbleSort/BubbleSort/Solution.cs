using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class Solution
    {
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
