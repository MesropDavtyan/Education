using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            int[] arr = { 1, 8, 2, 5, 18, 57 };

            foreach (var item in solution.GetPrimeList(arr))
            {
                Console.WriteLine(item);
            }
        }
    }
}
