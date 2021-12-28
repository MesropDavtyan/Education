using System;

namespace MoveZeroes
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            solution.MoveZeroes(new int[] { 0, 1, 0, 3, 12, 0, 56, 0, 0 });

            Console.WriteLine("Hello World!");
        }
    }
}
