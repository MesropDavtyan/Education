using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestUnique
{
    class Solution
    {
        public int GetOldestUnique(int[] numbers)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (dict.TryGetValue(numbers[i], out _))
                {
                    dict[numbers[i]] = i;
                }
                else
                {
                    dict.Add(numbers[i], i);
                }
            }

            var minIndex = int.MaxValue;
            var minValue = 0;

            foreach (var item in dict)
            {
                if (item.Value == 0)
                {
                    return item.Key;
                }
                else if(item.Value < minIndex)
                {
                    minIndex = item.Value;
                    minValue = item.Key;
                }
            }

            return minValue;
        }
    }
}
