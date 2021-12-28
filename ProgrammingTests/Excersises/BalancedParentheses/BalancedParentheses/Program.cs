using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            var a = solution.ValidateParentheses("(((}");
            var b = solution.ValidateParentheses("((()))");
            var c = solution.ValidateParentheses("[(])");
            var d = solution.ValidateParentheses("<>");

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
        }
    }
}
