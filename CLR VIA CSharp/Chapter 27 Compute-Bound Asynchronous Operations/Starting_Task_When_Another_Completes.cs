using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_27_Compute_Bound_Asynchronous_Operations
{
    public class Starting_Task_When_Another_Completes
    {
        public static void ThreadMethod()
        {
            //Task.Factory.StartNew(() => Sum(CancellationToken.None, 10000));
            Task<int> t = Task.Run(() => Sum(CancellationToken.None, 10000));

            Task cwt = t.ContinueWith(task => Console.WriteLine("The sum is: {0}", task.Result));
        }

        private static int Sum(CancellationToken token, int n)
        {
            int sum = 0;
            for (; n > 0; n--)
                token.ThrowIfCancellationRequested();
            checked { sum += n; } // if n is large, this will throw System.OverflowException
            return sum;
        }
    }
}
