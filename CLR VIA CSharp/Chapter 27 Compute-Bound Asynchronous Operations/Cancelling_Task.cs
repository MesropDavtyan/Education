using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_27_Compute_Bound_Asynchronous_Operations
{
    public class Cancelling_Task
    {
        public static void ThreadMethod()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task<int> task = Task.Run(() => Sum(cts.Token,100000000), CancellationToken.None);

            cts.Cancel();

            try
            {
                Console.WriteLine("Sum is {0}", task.Result);
            }
            catch (AggregateException ex)
            {
                ex.Handle(e => e is OperationCanceledException);
                Console.WriteLine("Sum was canceled");
            }

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
