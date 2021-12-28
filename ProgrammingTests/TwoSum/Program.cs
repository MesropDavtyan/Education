using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            int[] nums = { 2, 7, 11, 15 };

            var a = solution.TwoSum(nums, 9);

            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
        }
    }
}
