using System;

namespace ClimbStairs
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            //Console.WriteLine("2 -> " + solution.ClimbStairs(2));
            //Console.WriteLine("3 -> " + solution.ClimbStairs(3));
            Console.WriteLine("5 -> " + solution.ClimbStairsDP(5));
        }
    }
}
