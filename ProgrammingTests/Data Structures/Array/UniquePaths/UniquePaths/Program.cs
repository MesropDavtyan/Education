using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            Console.WriteLine(solution.UniquePaths(7,3));
        }
    }
}
