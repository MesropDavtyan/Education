using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArrayDuplicates
{
    public class Solution
    {
        public void PrintDuplicates(int[] arr)
        {
            Dictionary<int, int> collection = new Dictionary<int, int>();

            foreach (var item in arr)
            {
                int count;

                if (collection.TryGetValue(item, out count))
                {
                    collection[item] = count + 1;
                }
                else
                {
                    collection[item] = 1;
                }
            }

            foreach (var item in collection)
            {
                if (item.Value != 1)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }

        //public bool ContainsDuplicate(int[] nums)
        //{
        //    Dictionary<int, int> collection = new Dictionary<int, int>();

        //    bool containsDuplicate = false;

        //    foreach (var item in nums)
        //    {
        //        int count;

        //        if (collection.TryGetValue(item, out count) && count > 1)
        //        {
        //            containsDuplicate = true;
        //        }
        //        else if (collection.TryGetValue(item, out count) && count <= 1)
        //        {
        //            collection[item] = count + 1;
        //        }
        //        else
        //        {
        //            collection[item] = 1;
        //        }
        //    }

        //    return containsDuplicate;
        //}

        public int MaxProfit(int[] prices)
        {
            int min = 0;
            int max = 0;
            int indexOfMin = 0;
            int indexOfMax = 0;

            if (prices.Length > 0)
            {
                min = prices[0];

                for (var i = 0; i < prices.Length; i++)
                {
                    if (prices[i] <= min && i != prices.Length - 1)
                    {
                        min = prices[i];
                        indexOfMin = i;
                    }
                    if (prices[i] >= max && i > indexOfMin)
                    {
                        max = prices[i];
                        indexOfMax = i;
                    }
                }
            }

            if (indexOfMax > indexOfMin)
            {
                return max - min;
            }
            return 0;
        }
    }
}
