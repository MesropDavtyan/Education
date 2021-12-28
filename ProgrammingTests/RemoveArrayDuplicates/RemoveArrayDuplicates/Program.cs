using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveArrayDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            int[] arr = { 1, 2, 58, 6, 58, 5, 6 };

            var dict = solution.RemoveDuplicates(arr);

            foreach (var item in dict)
            {
                Console.WriteLine(item);
            }
        }
    }
}
