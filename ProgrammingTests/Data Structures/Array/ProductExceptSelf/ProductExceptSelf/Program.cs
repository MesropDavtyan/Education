using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductExceptSelf
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            int[] arr = { 1, 2, 3, 4 };

            var collection = solution.ProductExceptSelf(arr);

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
