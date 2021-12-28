using System;

namespace ReverseNumber
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();
            Console.WriteLine(solution.ReverseNumber(9));
            Console.WriteLine(solution.ReverseNumber(-512));
            Console.WriteLine(solution.ReverseNumber(-120));
            Console.WriteLine(solution.ReverseNumber(1534236469));
            Console.WriteLine(solution.ReverseNumber(-2147483648));
        }
    }
}
