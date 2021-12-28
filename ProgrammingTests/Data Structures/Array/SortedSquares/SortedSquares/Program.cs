using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedSquares
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] result = solution.SortedSquares(new int[] { -5, -3, -2, -1 });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
