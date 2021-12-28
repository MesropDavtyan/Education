using System;
using System.Collections.Generic;

namespace RemoveDuplicates
{
    public class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            //HashSet<int> collection = new HashSet<int>();
            //List<int> newNums = new List<int>();

            //foreach (var num in nums)
            //{
            //    collection.Add(num);
            //}

            //foreach (var item in collection)
            //{
            //    newNums.Add(item);
            //}

            //for (int i = 0; i < newNums.Count; i++)
            //{
            //    nums[i] = newNums[i];
            //}

            //return collection.Count;

            if (nums.Length == 0)
            {
                return 0;
            }

            int idx = 0;

            for (int i = 1; i < nums.Length; i++) {
                if (nums[i] != nums[idx]) {
                    nums[++idx] = nums[i];
                }
            }

            return idx + 1;
        }
    }
}
