package org.example.dataStructures.array.twoSum;

import java.util.HashMap;

public class Solution {
    public static int[] twoSum(int[] nums, int target) {
        HashMap<Integer, Integer> collection = new HashMap<>();

        for (int i = 0; i < nums.length; i++) {
            if (collection.get(target - nums[i]) != null){
                return new int[] {collection.get(target - nums[i]), i};
            }
            collection.putIfAbsent(nums[i], i);
        }

        throw new IllegalArgumentException("No result");
    }
}
