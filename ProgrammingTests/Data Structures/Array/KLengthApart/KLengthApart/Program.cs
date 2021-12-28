using System;

namespace KLengthApart
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine(solution.KLengthApart(new int[] { 0, 1, 0, 1, 0, 0, 1, 0, 0, 1 }, 2)); // false
            Console.WriteLine(solution.KLengthApart(new int[] { 0, 1, 0, 1 }, 1)); // true
            Console.WriteLine(solution.KLengthApart(new int[] { 1, 0, 0, 0, 1, 0, 0, 1 }, 2)); // true
            Console.WriteLine(solution.KLengthApart(new int[] { 1, 0, 0, 1, 0, 1 }, 2)); // false
            Console.WriteLine(solution.KLengthApart(new int[] { 1, 0, 0, 0 }, 1)); // true
        }
    }
}
