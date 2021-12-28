using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            Console.WriteLine(solution.IsRectangle(-6, 3, 0, 6, 2, 2, -4, -1));
        }
    }
}
