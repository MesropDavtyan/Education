using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        public static async Task Foo()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Async Method");
            }
            );
        }

        public static void Foo2()
        {
            Console.WriteLine("Sync Method");
        }

        public static async Task Foo3()
        {
            await Foo();
            Foo2();
        }

        public static void Foo4()
        {
            Console.WriteLine("Unconnected Method");
        }

        public static void MyFoo()
        {
            Console.WriteLine("Starting MyFoo");
            Thread.Sleep(2000);
            //await Task.Delay(5000);
            Console.WriteLine("MyFoo");
        }

        static async Task Main(string[] args)
        {
             MyFoo();
            //Foo3();
            Foo4();
            //Console.ReadLine();
        }
    }
}
