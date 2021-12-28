using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumInvertedTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Solution();

            //obj.Foo(1, 2);
            obj.Foo3(5);
            obj.MaxPathSum2(new int[,] { { 1, 5, 3 }, { 4, 8, 0 }, { 1, 0, 0 } });
        }
    }
}
