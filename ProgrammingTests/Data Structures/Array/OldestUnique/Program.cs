using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldestUnique
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            int[] arr = new int[] { 4, 2, 8, 5, 1, 4, 2 };

            Console.WriteLine(solution.GetOldestUnique(arr));
        }
    }
}
