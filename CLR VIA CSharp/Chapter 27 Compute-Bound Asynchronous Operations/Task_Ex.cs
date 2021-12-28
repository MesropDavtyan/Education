using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_27_Compute_Bound_Asynchronous_Operations
{
    public class Task_Ex
    {
        public static void ThreadMethod()
        {
            Task<int> task = new Task<int>(() => Sum(100000000));

            task.Start();

            task.Wait();

            Console.WriteLine("Sum is {0}", task.Result);
        }

        private static int Sum(int n)
        {
            int sum = 0;
            for (; n > 0; n--)
                checked { sum += n; } // if n is large, this will throw System.OverflowException
            return sum;
        }
    }
}
