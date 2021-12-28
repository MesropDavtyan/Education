using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            int[] arr = { 1, 2, 3, 4, 5, 6 };

            //int[] shuffArr = solution.ShuffleArray(arr);

            //foreach (var item in shuffArr)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine(solution.RemoveChar("foo bar foo $ bar $ foo bar $ "));
        }
    }
}
