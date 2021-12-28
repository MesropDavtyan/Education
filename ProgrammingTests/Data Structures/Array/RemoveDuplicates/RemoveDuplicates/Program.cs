using System;

namespace RemoveDuplicates
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine(solution.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }));
        }
    }
}
