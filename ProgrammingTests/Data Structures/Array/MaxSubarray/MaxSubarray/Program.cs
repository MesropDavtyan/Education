using System;

namespace MaxSubarray
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine(solution.MaxSubArray(new int[] {-2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }
    }
}
