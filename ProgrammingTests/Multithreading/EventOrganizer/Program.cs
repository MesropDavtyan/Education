using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventOrganizer
{
    class Program
    {
        //+++++++++++++++++++++++++++++++  MULTITHREADING SANDBOX  +++++++++++++++++++++++++++++++++++++

        static void Main(string[] args)
        {
            // ========================  Passing parameters  ================================

            //Thread myThread = new Thread(() => Print("message from the first thread"));
            //myThread.Start();

            //new Thread(() =>
            //{
            //    Console.WriteLine("Some message");
            //    Console.WriteLine("From the second thread");
            //}).Start();

            //Thread myThirdThread = new Thread(Print);
            //myThirdThread.Start("message from the third thread");

            // ========================  Thread nameing ================================

            //Thread.CurrentThread.Name = "main";
            //Thread worker = new Thread(Go);
            //worker.Name = "worker";
            //worker.Start();
            //Go();

            // ========================  Join  ================================

            //Thread t = new Thread(Go);
            //t.Start();
            //t.Join();
            //Console.WriteLine("Thread had ended");

            // ========================  Signaling  ================================

            //ManualResetEvent signal = new ManualResetEvent(false);

            //new Thread(() =>
            //{
            //    Console.WriteLine("Waiting for a signal...");
            //    signal.WaitOne();
            //    signal.Dispose();
            //    Console.WriteLine("Got a signal!");
            //    signal.Reset();
            //}).Start();

            //Thread.Sleep(2000);
            //signal.Set();


            // ========================  Thread Pool ================================

            ThreadPool.QueueUserWorkItem(Go);
            ThreadPool.QueueUserWorkItem(Go, 1993);
            ThreadPool.QueueUserWorkItem(n => Console.WriteLine("Hello"));

            Console.ReadLine();

            // =========================  TPL  ============================

            //Task.Factory.StartNew(Go).Wait(5000);

            //Task<string> task = Task.Factory.StartNew<string>(() => DownloadString("http://www.linqpad.net"));

            //Go();

            //Console.WriteLine(task.Result);
        }

        static void Go(object data)
        {
            //Thread.Sleep(2000);
            Console.WriteLine($"Hello from the thread pool: {data}");
        }

        //static void Go()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Console.Write("y");
        //    }
        //}

        static string DownloadString(string url)
        {
            using (var wc = new System.Net.WebClient())
            {
                return wc.DownloadString(url);
            }
        }

        //static void Print(object message)
        //{
        //    Console.WriteLine($"This is a test message. The content of the message is: {message}");
        //}
    }
}
