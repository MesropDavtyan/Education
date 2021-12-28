using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_27_Compute_Bound_Asynchronous_Operations
{
    public class Simple_Compute_Bound_Operation_Using_ThreadPool
    {
        public static void ThreadMethod()
        {
            Console.WriteLine("Main thread: queuing an asynchronous operation");

            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);

            Console.WriteLine("Main thread: Doing other work here...");
            // Simulating other work (5 seconds)
            Thread.Sleep(5000);

            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }

        // This method's signature must match the WaitCallback delegate
        public static void ComputeBoundOp(Object state)
        {
            // This method is executed by a thread pool thread
            Console.WriteLine("In ComputeBoundOp: state={0}", state);

            // Simulates other work (1 second)
            Thread.Sleep(1000);

            // When this method returns, the thread goes back
            // to the pool and waits for another task
        }
    }
}
