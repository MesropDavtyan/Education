using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter_27_Compute_Bound_Asynchronous_Operations
{
    public class Child_Tasks
    {
        public static void ThreadMethod()
        {
            Task<Int32[]> parent = new Task<Int32[]>(() =>
            {
                var results = new Int32[3]; // Create an array for the results
                                            // This tasks creates and starts 3 child tasks
                new Task(() => results[0] = Sum(10000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[1] = Sum(20000), TaskCreationOptions.AttachedToParent).Start();
                new Task(() => results[2] = Sum(30000), TaskCreationOptions.AttachedToParent).Start();
                // Returns a reference to the array (even though the elements may not be initialized yet)
                return results;
            });
            // When the parent and its children have run to completion, display the results
            var cwt = parent.ContinueWith(
            parentTask => Array.ForEach(parentTask.Result, Console.WriteLine));
            // Start the parent Task so it can start its children
            parent.Start();
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
