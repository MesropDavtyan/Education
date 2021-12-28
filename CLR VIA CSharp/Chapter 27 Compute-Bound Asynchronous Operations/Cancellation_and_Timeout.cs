using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_27_Compute_Bound_Asynchronous_Operations
{
    public class Cancellation_and_Timeout
    {
        public static void ThreadMethod()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            // Pass the CancellationToken and the number-to-count-to into the operation
            ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 1000));

            Console.WriteLine("Press <Enter> to cancel the operation");
            Console.ReadLine();

            // If Count returned already, Cancel has no effect on it
            cts.Cancel();
            // Cancel returns immidiately, and the method continues running here...

            Console.ReadLine();
        }

        private static void Count(CancellationToken token, int countTo)
        {
            for (int count = 0; count < countTo; count++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is cancelled");

                    // Exit the loop to stop the operation
                    break;
                }

                Console.WriteLine(count);

                // For demo, waste some time
                Thread.Sleep(200);
            }

            Console.WriteLine("Count is done");
        }
    }
}
