using System;
using static System.Diagnostics.Activity;

namespace Sandbox
{
    public class Foo
    {
        public Foo()
        {

        }

        public Semaphore sem1 = new Semaphore(0, 1);
        public Semaphore sem2 = new Semaphore(0, 1);

        public void First(Action printFirst)
        {
            // printFirst() outputs "first". Do not change or remove this line.
            printFirst();
            sem1.Release();
        }

        public void Second(Action printSecond)
        {
            sem1.WaitOne();
            // printSecond() outputs "second". Do not change or remove this line.
            printSecond();
            sem2.Release();
        }

        public void Third(Action printThird)
        {
            sem2.WaitOne();
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

        //----------------------------------------------------------------------------------------------------

        bool isTriggered = false;
        List<Task> taskList = new List<Task>();

        object locker = new object();

        public void SubmitTask(Task task)
        {
            lock (locker)
            {
                if (isTriggered)
                {
                    task.Start();
                }
                else
                {
                    Console.WriteLine("Adding task.");
                    taskList.Add(task);
                }
            }
        }

        public void Trigger()
        {
            lock (locker)
            {
                isTriggered = true;
                Console.WriteLine("TRIGGERED!!!");
                foreach (var task in taskList)
                {
                    task.Start();
                }
            }
        }
    }
    

    //----------------------------------------------------------------------------------------------------
    // 1. What will be displayed in a console by the following code?

    public static class Sample1
    {
        private class A
        {
            public int Value;

            public A(int value)
            {
                Value = value;
            }
        }

        private struct B
        {
            public int Value;

            public B(int value)
            {
                Value = value;
            }
        }

        //public static void Main()
        //{
        //    A a1 = new A(1);
        //    A a2 = a1;
        //    a1.Value = 2;
        //    Console.WriteLine(a2.Value); // 2

        //    B b1 = new B(a2.Value);
        //    B b2 = b1;
        //    b1.Value = 4;

        //    Console.WriteLine(b2.Value); // 2

        //    B b3 = new B(b2.Value);
        //    object x = b3;
        //    b3.Value = 5;

        //    Console.WriteLine(((B)x).Value); // 2
        //}
    }

    //----------------------------------------------------------------------------------------------------
    // 2. What needs to be added to a class A to make the code compilable?

    //public class A : IEnumerable<int>
    //{
    //    private readonly int[] _array;

    //    public A(int[] array)
    //    {
    //        _array = array;
    //    }

    //    public int Length
    //    {
    //        get { return _array.Length; }
    //    }


    //    public Enumerator<int> GetEnumerator()
    //    {
    //        return _array.GetEnumerator();
    //    }


    //}

    //public static void Main()
    //{
    //    A a = new A(new[] { 1, 2, 3, 4, 5, 6, 7 });

    //    for (int i = 0; i < a.Length; i++)
    //        Console.WriteLine(a[i]);

    //    foreach (int i in a)
    //        Console.WriteLine(i);
    //}

    //----------------------------------------------------------------------------------------------------
    // 3. What will be displayed in a console by the following code?

    public static class Sample3
    {
        public class MyException : Exception
        {
        }

        public static void Execute(Action method)
        {
            try
            {
                method();
            }
            catch (MyException ex)
            {
                Console.WriteLine("MyException");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception");
            }
            catch
            {
                Console.WriteLine("Catch");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }

        public static void Step1()
        {
            Console.WriteLine("Step1()");
            throw new MyException();
        }

        public static void Step2()
        {
            Console.WriteLine("Step2()");
            throw new Exception();
        }

        public static void Step3()
        {
            Console.WriteLine("Step3()");
        }

        //public static void Main()
        //{
        //    Execute(Step1); // Step1(), MyException, Finally
        //    Execute(Step2); // Step2(), Exception, Finally
        //    Execute(Step3); // Step3(), Finally
        //}
    }

    //----------------------------------------------------------------------------------------------------
    // 4. What will be displayed in a console by the following code?

    public static class Sample4
    {
        interface I
        {
            void F1();
            void F2();
        }

        class A : I
        {
            public virtual void F1() { Console.WriteLine("A::F1()"); }
            public virtual void F2() { Console.WriteLine("A::F2()"); }
        }

        class B : A
        {
            public override void F1() { Console.WriteLine("B::F1()"); }
            public new void F2() { Console.WriteLine("B::F2()"); }
        }

        public static void Main()
        {
            A a1 = new B();
            a1.F1(); // B::F1()
            a1.F2(); // A::F2()

            I x1 = a1;
            x1.F1(); // B::F1()
            x1.F2(); // A::F2()

            A a2 = x1 as A;
            a2.F1(); // B::F1()
            a2.F2(); // A::F2()

            B b1 = a2 as B;
            b1.F1();
            b1.F2();

            A a3 = new A();
            I x2 = a3 as B;
            x2.F1();
        }
    }

    //----------------------------------------------------------------------------------------------------
    // 5. What will be displayed in a console by the following code?

    public static class Sample5
    {
        private class A : IDisposable
        {
            public A() { Console.WriteLine("A()"); }
            ~A() { Console.WriteLine("~A()"); }
            public void Dispose() { Console.WriteLine("Dispose()"); }
            public void SomeFaultyMethod() { throw new Exception(); }
        }

        public static void Execute(Action method)
        {
            try
            {
                method();
            }
            catch
            {
                Console.WriteLine("Catch");
            }
        }

        public static void Step1()
        {
            Console.WriteLine("Step1");
            A a = new A();
            a.SomeFaultyMethod();
        }

        public static void Step2()
        {
            Console.WriteLine("Step2");
            A a = new A();
            a.SomeFaultyMethod();
            a.Dispose();
        }

        public static void Step3()
        {
            Console.WriteLine("Step3");
            using (A a = new A())
            {
                a.SomeFaultyMethod();
            }


            // WRONG

            //try
            //{
            //    A a = new A();
            //    a.SomeFaultyMethod();
            //}
            //finally
            //{
            //    a.Dispose();
            //}

            //// Correct
            //A a = new A();

            //try
            //{
            //    a.SomeFaultyMethod();
            //}
            //finally
            //{
            //    a.Dispose();
            //}
        }

        //public static void Main()
        //{
        //    Execute(Step1); // Step1, A(), Catch 
        //    //Correct - Step1, A(), Catch, ~A()
        //    Execute(Step2); // Step2, A(), Catch 
        //    //Correct - Step2, A(), Catch, ~A()
        //    Execute(Step3); // Step3, A(), Dispose(), Catch 
        //    //Correct - Step3, A(), Dispose(), Catch, ~A()
        //}
    }

    //----------------------------------------------------------------------------------

    //class A
    //{
    //    public int _x;
    //}

    //A a = new A();
    //a._x = 1;

    //void Thread1()
    //{
    //    lock (a)
    //    {
    //        Sleep(long time)
    
    //}
    //}

    //void Thread2()
    //{
    //    a._x = 2; //??? Correct - 2
    //}

    //----------------------------------------------------------------------------------------------------
    // 6. What will be displayed in a console by the following code?

    public static class Sample6
    {
        private class A
        {
            private readonly object _lock = new object();
            private readonly Mutex _mutex = new Mutex(false, "Mutex");
            private readonly Semaphore _semaphore = new Semaphore(0, 1);
            private readonly AutoResetEvent _event = new AutoResetEvent(false);

            public void Start()
            {
                var threads = new[]
                {
                    new Thread(Thread1),
                    new Thread(Thread2),
                    new Thread(Thread3)
                };

                foreach (var thread in threads)
                    thread.Start();

                foreach (var thread in threads)
                    thread.Join();
            }

            private void Thread1()
            {
                _event.WaitOne();
                lock (_lock)
                {
                    Console.WriteLine("Thread 1");
                }
                _event.Set();
            }

            private void Thread2()
            {
                _mutex.WaitOne();
                lock (_lock)
                {
                    _event.Set();
                    Console.WriteLine("Thread 2");
                }
                _event.WaitOne();
                _semaphore.Release(1);
                _mutex.ReleaseMutex();
            }

            private void Thread3()
            {
                _semaphore.WaitOne();
                lock (_lock)
                {
                    Console.WriteLine("Thread 3");
                }
            }
        }

        //public static void Main()
        //{
        //    new A().Start();
        //    // 3, 2 ,1
        //    // Correct 2, 1, 3
        //}
    }

    //----------------------------------------------------------------------------------------------------
    // 7. Find mistake(-s) in the following code:

    public static class Sample7
    {
        interface IA<in T>
        {
            void Print(T data);
        }

        class A<T> : IA<T>
        {
            public void Print(T data) { }
        }

        interface IB<out T>
        {
            T SomeProperty { get; }
        }

        class B<T> : IB<T>
        {
            public T SomeProperty { get; private set; }
        }

        class C<T> : IA<T>, IB<T>
        {
            public T SomeProperty { get; private set; }
            public void Print(T data) { }
        }

        //public static void Test()
        //{
        //    IA<string> as1 = new A<string>();
        //    IA<object> ao1 = new A<object>();
        //    IA<string> ac2 = ao1;
        //    IA<object> ao2 = as1;

        //    B<string> bs1 = new B<string>();
        //    B<object> bo1 = new B<object>();
        //    IB<string> bc2 = bo1;
        //    IB<object> bo2 = bs1;

        //    C<string> cs1 = new C<string>();
        //    C<object> co1 = new C<object>();
        //    C<string> cc2 = bo1;
        //    C<object> co2 = bs1;
        //}
    }
}

