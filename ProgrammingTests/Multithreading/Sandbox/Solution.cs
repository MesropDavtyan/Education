using System;
using System.Collections;
using System.Collections.Concurrent;
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

    public static class Sample2
    {
        //-------------------- FROM -----------------------

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

        //-------------------- TO -----------------------

        public class A : IEnumerable
        {
            private readonly int[] _array;

            public A(int[] array)
            {
                _array = array;
            }

            public int Length
            {
                get { return _array.Length; }
            }

            public int this[int i]
            {
                get { return _array[i]; }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _array.GetEnumerator();
            }

            //public IEnumerator GetEnumerator()
            //{
            //    return _array.GetEnumerator();
            //}
        }

        //public static void Main()
        //{
        //    A a = new A(new[] { 1, 2, 3, 4, 5, 6, 7 });

        //    for (int i = 0; i < a.Length; i++)
        //        Console.WriteLine(a[i]);

        //    foreach (int i in a)
        //        Console.WriteLine(i);

        //    //while (a.GetEnumerator().MoveNext())
        //    //{
        //    //    Console.WriteLine(a.GetEnumerator().Current);
        //    //}
        //}
    }


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

        //public static void Main()
        //{
        //    A a1 = new B();
        //    a1.F1(); // B::F1()
        //    a1.F2(); // A::F2()

        //    I x1 = a1;
        //    x1.F1(); // B::F1()
        //    x1.F2(); // A::F2()

        //    A a2 = x1 as A;
        //    a2.F1(); // B::F1()
        //    a2.F2(); // A::F2()

        //    B b1 = a2 as B;
        //    b1.F1(); // B::F1()
        //    b1.F2(); // B::F2()

        //    A a3 = new A();
        //    I x2 = a3 as B; // null
        //    x2.F1(); // NullReferenceException
        //}
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
        //    Execute(Step1); // Step1, A(), Catch, ~A()
        //    Execute(Step2); // Step2, A(), Catch, ~A()
        //    Execute(Step3); // Step3, A(), Dispose(), Catch, ~A()
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
        //    new A().Start(); // 2, 1, 3
        //}
    }

    //----------------------------------------------------------------------------------------------------
    // 7. Find mistake(-s) in the following code:

    public static class Sample7
    {
        interface IA<in T> // contravariant
        {
            void Print(T data);
        }

        class A<T> : IA<T>
        {
            public void Print(T data) { }
        }

        interface IB<out T> // covariant
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

        //public static void Main()
        //{
        //    IA<string> as1 = new A<string>();
        //    IA<object> ao1 = new A<object>();
        //    IA<string> ac2 = ao1;
        //    IA<object> ao2 = (IA<object>)as1; //as1; contravariant

        //    B<string> bs1 = new B<string>();
        //    B<object> bo1 = new B<object>();
        //    IB<string> bc2 = (IB<string>)bo1; // bo1; contravariant
        //    IB<object> bo2 = bs1;

        //    C<string> cs1 = new C<string>();
        //    C<object> co1 = new C<object>();
        //    C<string> cc2 = bo1; // covariant, casting is not valid
        //    C<object> co2 = bs1; // covariant, casting is not valid
        //}
    }

    //----------------------------------------------------------------------------------------------------
    public class Q1
    {
        public class FooTest : IEquatable<FooTest>
        {
            public int Value { get; set; }

            public bool Equals(FooTest? other)
            {
                return Value == other?.Value;
            }
        }

        //public static void Main()
        //{
        //    var ref1 = new FooTest { Value = 1 };
        //    var ref2 = new FooTest { Value = 1 };

        //    Console.WriteLine(ref1.Equals(ref2)); // true
        //    Console.WriteLine(ref1 == ref2); // false
        //}
    }

    //----------------------------------------------------------------------------------------------------
    public class Q2
    {
        public class FooTest2
        {
            private readonly Int32 _value;

            public FooTest2(Int32 value) => _value = value;

            public override int GetHashCode() => 1;

            public override bool Equals(object? obj) =>
                obj is FooTest2 other && _value == other._value;
        }

        //public static void Main()
        //{
        //    Dictionary<FooTest2, string> dict = new Dictionary<FooTest2, string>();

        //    dict.Add(new FooTest2(1), "Test1");
        //    //dict.Add(new FooTest2(2), "Test2");

        //    Console.WriteLine(dict[new FooTest2(1)]);
        //}
    }

    //----------------------------------------------------------------------------------------------------
    public class Q3
    {
        public class TestDisposable : IDisposable
        {
            public void Do()
            {
                Console.WriteLine("Working...");
            }

            public void Dispose()
            {
                Console.WriteLine("Disposing the object...");
                this.Dispose();
            }
        }

        //public static void Main()
        //{
        //    using (TestDisposable disposable = new TestDisposable())
        //    {
        //        disposable.Do();
        //    }

        //    //------------------------- SAME AS -----------------------------------

        //    //TestDisposable disposable = null;
        //    //try
        //    //{
        //    //    disposable = new TestDisposable();
        //    //    disposable.Do();
        //    //}
        //    //finally
        //    //{
        //    //    disposable?.Dispose();
        //    //}
        //}
    }

    //----------------------------------------------------------------------------------------------------
    public class Q4
    {
        //public static void Main()
        //{
        //    var container = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        //    {
        //        "Test",
        //        "test",
        //        "Test",
        //        "test",
        //        "hash",
        //        "",
        //        String.Empty
        //    };

        //    var count = container.Count; // 3
        //    var found = container.Contains("test"); // true

        //    Console.WriteLine(count);
        //    Console.WriteLine(found);
        //}
    }

    //----------------------------------------------------------------------------------------------------
    // Will instances foo and bar be ever collected by GC before application termination after creating such a cycle link? // yes

    public class Q5
    {
        public class Foo
        {
            public Bar Bar { get; set; }
        }

        public class Bar
        {
            public Foo Foo { get; set; }
        }

        //public static void Main()
        //{
        //    Foo foo = new Foo();
        //    Bar bar = new Bar();
        //    foo.Bar = bar;
        //    bar.Foo = foo;
        //    foo = null;
        //    bar = null;
        //    // ...execution continues
        //}
    }

    //----------------------------------------------------------------------------------------------------
    public class Q7
    {
        public class Foo
        {
            public int Value { get; }

            public Foo(int value)
            {
                Value = value;
                throw new InvalidOperationException();
            }
        }

        //public static void Main()
        //{
        //    Foo foo = null;
        //    try
        //    {
        //        foo = new Foo(value: 23);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Failed to create foo"); // Failed to create foo
        //    }
        //    Console.WriteLine(foo.Value); // An unhadled NullReferenceException will be thrown
        //}
    }

    //----------------------------------------------------------------------------------------------------
    public class Q8
    {
        public static class Foo
        {
            private static readonly object s_lockObject = new object();

            public static void Bar(Int32 taskNumber)
            {
                lock (s_lockObject)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write(taskNumber);
                    }
                }
            }
        }

        //public static void Main()
        //{
        //    Task t1 = new Task(() => Foo.Bar(1));
        //    Task t2 = new Task(() => Foo.Bar(2));

        //    t1.Start();
        //    t2.Start();

        //    t1.Wait();
        //    t2.Wait();

        //    // output will be 111222 or 222111
        //}
    }

    //----------------------------------------------------------------------------------------------------
    // The main program could finish and interrupt the task execution
    // The task might finish before all values are enqueued
    // The acquired lock prevents enqueueing

    public class Q9
    {
        //public static void Main()
        //{
        //    ConcurrentQueue<int> queue = new();

        //    Task.Run(() =>
        //    {
        //        lock (queue)
        //        {
        //            while (queue.TryDequeue(out int value))
        //            {
        //                Console.WriteLine(value);
        //            }
        //        }
        //    });

        //    for (int i = 0; i < 1000; i++)
        //    {
        //        queue.Enqueue(i);
        //    }
        //}
    }

    //----------------------------------------------------------------------------------------------------
    // Update the Answer.Run cod by implementing the following rules:
    //
    //  1. If an exception is thrown by s.Execute() then call c.Rollback() and propogate the exception, otherwise call c.Commit()
    //  2. Any method of Service s can throw an exception. In any circumstances c.Close() must be called before leaving the method Run(Service s, Connection c)

    public class Q10
    {
        public class Answer
        {
            // Before
            //public void Run(Service s, Connection c)
            //{
            //    s.SetConnection(c);
            //    s.Execute();
            //}

            // After
            public void Run(Service s, Connection c)
            {
                try
                {
                    s.SetConnection(c);
                    try
                    {
                        s.Execute();
                        c.Commit();
                    }
                    catch (Exception ex)
                    {
                        c.Rollback();
                        throw;
                    }
                }
                finally
                {
                    c.Close();
                }
            }
        }

        // Definition of a service
        public interface Service
        {
            void Execute();
            void SetConnection(Connection c);
        }

        // Definition of the connection
        public interface Connection
        {
            void Commit();
            void Rollback();
            void Close();
        }

        class MyService : Service
        {
            public void Execute()
            {
                Console.WriteLine("Execute");
            }

            public void SetConnection(Connection c)
            {
                Console.WriteLine("SetConnection");
            }
        }

        class MyConnection : Connection
        {
            public void Close()
            {
                Console.WriteLine("Close");
            }

            public void Commit()
            {
                Console.WriteLine("Commit");
            }

            public void Rollback()
            {
                Console.WriteLine("Rollback");
            }
        }

        //public static void Main(String[] args)
        //{
        //    new Answer().Run(new MyService(), new MyConnection());
        //}
    }

    //----------------------------------------------------------------------------------------------------
    // Implement a class DisposableScope which provides methods for adding and removing IDisposable objects.
    // The DisposableScope.Dispose method must dospose objects in a REVERSE order of how they were added.
    public class Q11
    {
        public sealed class DisposableScope : IDisposable
        {
            public List<IDisposable> disposables = new List<IDisposable>();

            public DisposableScope()
            {
            }

            public void Dispose()
            {
                for (int i = disposables.Count - 1; i >= 0; i--)
                {
                    disposables[i].Dispose();
                }
            }

            public void Add(IDisposable disposable)
            {
                disposables.Add(disposable);
            }

            public void Remove(IDisposable disposable)
            {
                if (disposables.Count > 0)
                {
                    disposables.Remove(disposable);
                }
            }
        }

        public class DisposableItem : IDisposable
        {
            public string Name { get; set; }

            public DisposableItem(string name)
            {
                Name = name;
            }

            public void Dispose()
            {
                Console.WriteLine($"{this.Name} was disposed.");
            }
        }

        //public static void Main()
        //{
        //    DisposableItem item1 = new DisposableItem("item 1");
        //    DisposableItem item2 = new DisposableItem("item 2");
        //    DisposableItem item3 = new DisposableItem("item 3");

        //    using (DisposableScope scope = new())
        //    {
        //        scope.Add(item1);
        //        Console.WriteLine($"{item1.Name} was added.");
        //        scope.Add(item2);
        //        Console.WriteLine($"{item2.Name} was added.");
        //        scope.Add(item3);
        //        Console.WriteLine($"{item3.Name} was added.");
        //        scope.Remove(item2);
        //        Console.WriteLine($"{item2.Name} was removed.");
        //    }
        //}
    }

    //----------------------------------------------------------------------------------------------------
    // Max Length of sequence of repeating symbols:
    // 
    // Given a stirng of ASCII characters, find a maximum length of a subsequence of identical characters.
    //
    // Examples:
    //
    // IN: abbbcc OUT: 3
    // IN: aabccaaaa OUT: 4
    public class Q12
    {
        class Algotithm
        {
            public static int FindMaxSubstringLength(string str)
            {
                int maxLen = 0;
                int currLen = 1;

                for (int i = 1; i < str.Length; i++)
                {
                    if (str[i] == str[i - 1])
                    {
                        currLen++;
                    }
                    else
                    {
                        maxLen = Math.Max(maxLen, currLen);
                        currLen = 1;
                    }
                }

                return Math.Max(maxLen, currLen);
            }
        }

        public static void Main()
        {
            Console.WriteLine(Algotithm.FindMaxSubstringLength("abbbcc"));
            Console.WriteLine(Algotithm.FindMaxSubstringLength("aabccaaaa"));
        }
    }

    //----------------------------------------------------------------------------------------------------
    // There are two tasks which print numbers to the console. The first task prints only odd numbers: 1,3,5,7...
    // The second task prints only odd numbers: 2,4,6,8...
    // Implemet the syncronization of PrintOdd() and PrintEven() methods in Algorithm class so that the numbers will be printed ascending: 1,2,3,4,5,6,7,8,9,10...
    public class Q13
    {
        class Algotithm
        {
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
}
