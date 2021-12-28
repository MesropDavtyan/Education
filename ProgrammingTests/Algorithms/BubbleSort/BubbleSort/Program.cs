using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            int[] arr = { 5, 3, 7, 1, 25, 12 };

            solution.Sort(arr);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
