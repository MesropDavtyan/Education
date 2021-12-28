using System;

namespace RemoveElement
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine(solution.RemoveElement(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2));
        }
    }
}
