using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindArrayDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            int[] arr = { 5, 8, 9, 78, 5 };
            //int[] arr = {7,6,4,3,1};

            solution.PrintDuplicates(arr);
        }
    }
}
