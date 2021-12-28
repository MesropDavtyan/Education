using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Collections;

namespace Chapter_27_Compute_Bound_Asynchronous_Operations
{
    

    class Program
    {
        static void Main(string[] args)
        {
            //Simple_Compute_Bound_Operation_Using_ThreadPool.ThreadMethod();
            //Execution_Context.ThreadMethod();
            //Cancellation_and_Timeout.ThreadMethod();
            //Cancellation_Token.ThreadMethod();
            //Task_Ex.ThreadMethod();
            Cancelling_Task.ThreadMethod();
            //Starting_Task_When_Another_Completes.ThreadMethod();
        }
    }
}
