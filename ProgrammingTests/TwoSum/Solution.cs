using System;
using System.Collections.Generic;

//Given an array of integers, return indices of the two numbers such that they add up to a specific target.
//You may assume that each input would have exactly one solution, and you may not use the same element twice.

//Example:
//Given nums = [2, 7, 11, 15], target = 9,
//Because nums[0] + nums[1] = 2 + 7 = 9,
//return [0, 1].

namespace TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numDictionary = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                int difference = target - nums[i];
                if (numDictionary.TryGetValue(difference, out _))
                {
                    return new int[] { numDictionary[difference], i };
                }
                if (!numDictionary.TryGetValue(nums[i], out _))
                {
                    numDictionary.Add(nums[i], i);
                }
            }

            throw new ArgumentException("No result");
        }
    }
}
