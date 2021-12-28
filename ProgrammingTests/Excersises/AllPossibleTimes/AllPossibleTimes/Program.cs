using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPossibleTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            foreach (var item in solution.GetAllPossibleTimes(2, 3, 3, 2))
            {
                Console.WriteLine(item);
            }
        }
    }
}
