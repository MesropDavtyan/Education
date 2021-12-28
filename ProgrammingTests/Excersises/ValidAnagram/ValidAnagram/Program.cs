using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ValidAnagram
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            Console.WriteLine(solution.IsAnagram("anagram", "nagaram"));


            object obj1 = new object();
            object obj2 = new object();

            void Foo1()
            {
                lock (obj1)
                {
                    Thread.Sleep(3000);
                    lock (obj2)
                    {

                    }
                }
            }

            void Foo2()
            {
                lock (obj2)
                {
                    Thread.Sleep(3000);
                    lock (obj1)
                    {

                    }
                }
            }

            Task task1 = new Task(() => Foo1());
            Task task2 = new Task(() => Foo2());
        }
    }
}
