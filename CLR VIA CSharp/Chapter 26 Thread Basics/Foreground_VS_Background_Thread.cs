using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_26_Thread_Basics
{
    public class Foreground_VS_Background_Thread
    {
        public static void ThreadMethod()
        {
            // Create a new thread (default to foreground)
            Thread t = new Thread(() => Worker(5000));

            // Make the thread a background thread
            t.IsBackground = true;

            // Start the thread
            t.Start();

            // If t is a foreground thread, the application won't die for about 5 seconds
            // If t is a background thread, the application dies immidiately
            Console.WriteLine("Returning form Main");
        }

        private static void Worker(int miliSeconds)
        {
            // Simulate doing 5 seconds of work
            Thread.Sleep(miliSeconds);

            // The line below only gets displayed if this code is executed by a foreground thread
            Console.WriteLine("Returning from Worker");
        }
    }
}
