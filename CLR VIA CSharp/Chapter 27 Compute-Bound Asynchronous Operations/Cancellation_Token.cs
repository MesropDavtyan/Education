using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_27_Compute_Bound_Asynchronous_Operations
{
    public class Cancellation_Token
    {
        public static void ThreadMethod()
        {
            //// Create a CancellationTokenSource
            //var cts1 = new CancellationTokenSource();
            //cts1.Token.Register(() => Console.WriteLine("cts1 canceled"));

            //// Create another CancellationTokenSource
            //var cts2 = new CancellationTokenSource();
            //cts2.Token.Register(() => Console.WriteLine("cts2 canceled"));

            //// Create a new CancellationTokenSource that is canceled when cts1 or ct2 is canceled
            //var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cts1.Token, cts2.Token);
            //linkedCts.Token.Register(() => Console.WriteLine("linkedCts canceled"));

            //// Cancel one of the CancellationTokenSource objects (I chose cts2)
            //cts2.Cancel();

            //// Display which CancellationTokenSource objects are canceled
            //Console.WriteLine("cts1 canceled={0}, cts2 canceled={1}, linkedCts canceled={2}",
            //    cts1.IsCancellationRequested,
            //    cts2.IsCancellationRequested,
            //    linkedCts.IsCancellationRequested);

            CancellationTokenSource cts = new CancellationTokenSource();

            cts.Token.Register(() => DoWork(cts.Token));
            cts.Token.Register(() => DoWork2(cts.Token));

            ThreadPool.QueueUserWorkItem(o => DoWork(cts.Token));
            ThreadPool.QueueUserWorkItem(o => DoWork2(cts.Token));


            Console.ReadKey();
            cts.Cancel();
        }

        public static void DoWork(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                Console.WriteLine("It's working");
            }
            else
            {
                Console.WriteLine("It's canceled");
            }
        }

        public static void DoWork2(CancellationToken token)
        {
            if (!token.IsCancellationRequested)
            {
                Console.WriteLine("It's working2");
            }
            else
            {
                Console.WriteLine("It's canceled2");
            }
        }
    }
}
