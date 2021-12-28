using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var solution2 = new Solution2();
            var solution3 = new Solution3();

            //Console.WriteLine(solution.GetAllPossibleTimesCount(1, 8, 3, 2));

            //Console.WriteLine(solution2.OCRValidator("ba1", "1Ad"));

            Console.WriteLine(solution3.GetBiggestNumber(9876));
        }
    }
}
