using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_26_Thread_Basics
{
    public class Thread_Example
    {
        public static void ThreadMethod()
        {
            Console.WriteLine("Main thread: starting a dedicated thread to do an asynchronous operation");

            Thread dedicatedThread = new Thread(ComputeBoundOp);
            dedicatedThread.Start(5);

            Console.WriteLine("Main thread: Doing other work here...");
            // Simulates other work (3 second)
            Thread.Sleep(3000);

            // Wait for thread to terminate
            dedicatedThread.Join();
            Console.WriteLine("Hit <Enter> to end this program...");
            Console.ReadLine();
        }

        // This method's signiture must match the ParametrizedThreadStart delegate
        private static void ComputeBoundOp(Object state)
        {
            // This method is executed by a dedicated thread

            Console.WriteLine("In ComputeBoundOp: state={0}", state);
            // Simulates other work (1 second)
            Thread.Sleep(1000);

            // When this method returns, the dedicated thread dies
        }
    }
}
