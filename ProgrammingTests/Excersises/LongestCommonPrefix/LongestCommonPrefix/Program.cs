using System;

namespace LongestCommonPrefix
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            //Console.WriteLine(solution.LongestCommonPrefix(new string[] { "flower", "flow", "flight" }));
            //Console.WriteLine(solution.LongestCommonPrefix(new string[] { "dog", "racecar", "car" }));
            Console.WriteLine(solution.LongestCommonPrefix(new string[] { "aa", "ab" }));
        }
    }
}
