using System;

namespace PlusOne
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            int[] result = solution.PlusOne(new int[] { 9, 9, 9});

            foreach (var item in result)
            {
                Console.Write(item);
            }
        }
    }
}
