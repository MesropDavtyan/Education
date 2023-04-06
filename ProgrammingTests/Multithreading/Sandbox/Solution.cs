using System;

namespace Sandbox
{
    public class Foo
    {
        public Foo()
        {

        }

        public SemaphoreSlim sem1 = new SemaphoreSlim(0, 1);
        public SemaphoreSlim sem2 = new SemaphoreSlim(0, 1);

        public void First(Action printFirst)
        {
            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();
            sem1.Release();
        }

        public void Second(Action printSecond)
        {
            sem1.Wait();
            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();
            sem2.Release();
        }

        public void Third(Action printThird)
        {
            sem2.Wait();
            // printThird() outputs "third". Do not change or remove this line.
            printThird();
        }
    }

    public class Solution
	{
        //----------------------------------------------------------------------------------------------------

        private AutoResetEvent oddEvent = new AutoResetEvent(false);
        private AutoResetEvent evenEvent = new AutoResetEvent(false);

        public void PrintOdd()
        {
            for (int i = 1; i < 10; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                    evenEvent.Set();
                    oddEvent.WaitOne();
                }
            }
        }

        public void PrintEven()
        {
            for (int i = 1; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    evenEvent.WaitOne();
                    Console.WriteLine(i);
                    oddEvent.Set();
                }
            }
        }
    }
}

