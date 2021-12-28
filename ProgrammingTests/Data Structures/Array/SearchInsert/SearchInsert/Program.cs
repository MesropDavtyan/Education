using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchInsert
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine(solution.SearchInsert(new int[] { 1, 3, 5, 6 }, 0)); // 0
            Console.WriteLine(solution.SearchInsert(new int[] { 1, 3, 5, 6 }, 7)); // 4
            Console.WriteLine(solution.SearchInsert(new int[] { 1, 3, 5, 6 }, 2)); // 1
            Console.WriteLine(solution.SearchInsert(new int[] { 1, 3, 5, 6 }, 5)); // 2
            Console.WriteLine(solution.SearchInsert(new int[] { 1 }, 2)); // 1
            Console.WriteLine(solution.SearchInsert(new int[] { 1, 3 }, 2)); // 1
        }
    }
}
