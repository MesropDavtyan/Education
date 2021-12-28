using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayIntersections
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            var a = solution.GetIntersect(new int[] { 7, 5, 8, 16, 9, 8, 8, 8 }, new int[] { 1, 8, 16, 89, 8 });
        }
    }
}
