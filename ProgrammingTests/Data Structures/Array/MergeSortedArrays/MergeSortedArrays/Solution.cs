using System;
namespace MergeSortedArrays
{
    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int lastIndex = nums1.Length - 1;

            while (m > 0 && n > 0)
            {
                if (nums1[m - 1] > nums2[n - 1])
                {
                    nums1[lastIndex] = nums1[m - 1];
                    m--;
                }
                else
                {
                    nums1[lastIndex] = nums2[n - 1];
                    n--;
                }

                lastIndex--;
            }

            while (n > 0)
            {
                nums1[lastIndex] = nums2[n - 1];
                n--;
                lastIndex--;
            }

            foreach (var item in nums1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
