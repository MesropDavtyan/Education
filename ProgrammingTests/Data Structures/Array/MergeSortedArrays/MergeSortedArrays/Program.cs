using System;

namespace MergeSortedArrays
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            //solution.Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3 );
            //solution.Merge(new int[] { 1 }, 1, new int[] { }, 0);
            //solution.Merge(new int[] { 0 }, 0, new int[] { 1 }, 1);
            //solution.Merge(new int[] { 4, 5, 6, 0, 0, 0 }, 3, new int[] { 1, 2, 3 }, 3);
            solution.Merge(new int[] { 4, 0, 0, 0, 0, 0 }, 1, new int[] { 1, 2, 3, 5, 6 }, 5);
        }
    }
}
