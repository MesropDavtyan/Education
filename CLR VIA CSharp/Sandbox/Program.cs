using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sandbox
{
    /*class A
    {
        public void Foo(string b, int a)
        {

        }

        public string Foo(int a, string b)
        {
            return "something";
        }

        public string Foo(int i)
        {
            return i.ToString();
        }

        public virtual void Func()
        {
            Console.WriteLine("A");
        }
    }

    class B : A
    {
        public override void Func()
        {
            Console.WriteLine("B");
        }

        public B()
        {

        }

        public B(int a)
        {

        }
    }

    class C : B
    {
        //public C(int i) : base(i)
        //{

        //}

        public override void Func()
        {
            Console.WriteLine("C");
        }

        public string Foo(string text)
        {
            return text;
        }
    }*/

    class A
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

    class Program
    {
        static readonly string aaa;

        public async static void TestAsyncAwaitMethods()
        {
            ThreadPool.QueueUserWorkItem(o => Loader());

            await LongRunningMethod();
        }

        public static async Task<int> LongRunningMethod()
        {
            Console.WriteLine("Starting Long Running method...");
            await Task.Delay(5000);
            Console.WriteLine("End Long Running method...");
            return 1;
        }


        public static void Loader()
        {
            //var webRequest = (System.Net.HttpWebRequest)WebRequest.Create("https://msdn.microsoft.com/en-us/windows/desktop/ms762271");
            //webRequest.Credentials = CredentialCache.DefaultCredentials;
            //var webResponse = (HttpWebResponse)webRequest.GetResponse();
            //long fileSize = webResponse.ContentLength;
            //var filename = webResponse.Headers.Keys;
            string data = "C:/Users/Meda/Downloads/Test.xml";

            XDocument doc = XDocument.Load(data);
            Dictionary<string, string> dataDictionary = new Dictionary<string, string>();

            foreach (XElement element in doc.Descendants().Where(p => p.HasElements == false))
            {
                int keyInt = 0;
                string keyName = element.Name.LocalName;

                while (dataDictionary.ContainsKey(keyName))
                {
                    keyName = element.Name.LocalName + "_" + keyInt++;
                }

                dataDictionary.Add(keyName, element.Value);
            }
        }


        class Student
        {
            public int StudentID { get; set; }
            public String StudentName { get; set; }
            public int Age { get; set; }
        }

        static async Task Main(string[] args)
        {
            //new A().Start();

            //-----------------------------------------------------------------------------------------------------------------------------------

            //A[] myArr = new C[] { new C(), new C() };
            //ArrayList arrayList = new ArrayList();

            //Console.WriteLine(myArr.GetHashCode());

            //string[] names = { "Mesrop", "David", "Vahe", "Vanand" };

            //var filteredNames = from name in names
            //              where name.Contains('a')
            //              select name;

            //foreach (var name in filteredNames)
            //{
            //    Console.WriteLine(name);
            //}

            //-----------------------------------------------------------------------------------------------------------------------------------

            //Student[] students = {
            //    new Student { StudentID = 1, StudentName = "Mesrop", Age = 27 },
            //    new Student { StudentID = 2, StudentName = "David", Age = 28 },
            //    new Student { StudentID = 3, StudentName = "Vahe", Age = 28 },
            //    new Student { StudentID = 4, StudentName = "Vanand", Age = 25 },
            //    new Student { StudentID = 5, StudentName = "Narek", Age = 25 },
            //};

            //var filteredStudents = from student in students
            //                       where student.Age > 24 && student.Age < 28
            //                       select student;

            //Student[] filteredStudents = students.Where(s => s.Age > 24 && s.Age < 28).ToArray();

            //foreach(var student in filteredStudents)
            //{
            //    Console.WriteLine("ID: {0}, Name: {1}, Age: {2}", student.StudentID, student.StudentName, student.Age);
            //}

            //IEnumerable<Student> Foo(Student[] studentArray, int ageFrom, int ageBefore)
            //{
            //    foreach (var student in studentArray)
            //    {
            //        if (student.Age > ageFrom && student.Age < ageBefore)
            //        {
            //            yield return student;
            //        }
            //    }
            //}

            //foreach (var student in Foo(students, 24, 28))
            //{
            //    Console.WriteLine("ID: {0}, Name: {1}, Age: {2}", student.StudentID, student.StudentName, student.Age);
            //}

            //-----------------------------------------------------------------------------------------------------------------------------------

            //var obj1 = new Object();
            //var obj2 = new Object();

            //Thread myThread1 = new Thread(Foo1);
            //Thread myThread2 = new Thread(Foo2);

            //myThread1.Start("Test1");
            //myThread2.Start("Test2");

            //void Foo1(object message)
            //{
            //    lock (obj1)
            //    {
            //        Thread.Sleep(3000);
            //        lock (obj2)
            //        {

            //        }
            //    }
            //}

            //void Foo2(object message)
            //{
            //    lock (obj2)
            //    {
            //        Thread.Sleep(3000);
            //        lock (obj1)
            //        {

            //        }
            //    }
            //}

            //-----------------------------------------------------------------------------------------------------------------------------------

            //void Foofoo(CancellationToken ct, string threadName)
            //{
            //    if (ct.IsCancellationRequested)
            //    {
            //        Console.WriteLine("cancelled");
            //        ct.ThrowIfCancellationRequested();
            //    }
            //    Console.WriteLine(threadName);
            //}

            //CancellationTokenSource cts = new CancellationTokenSource();

            //Task task1 = Task.Factory.StartNew(() => Foofoo(cts.Token, "task1"));
            //Task task2 = Task.Factory.StartNew(() => Foofoo(cts.Token, "task2"));
            //task1.ContinueWith(task => Foofoo(cts.Token, "continued task3"));
            //Console.ReadKey();

            //if (Task.WaitAny(task1, task2) > 0)
            //{
            //    cts.Cancel();
            //}

            //-----------------------------------------------------------------------------------------------------------------------------------

            //ThreadPool.QueueUserWorkItem(o => Starting_Task_When_Another_Completes.Func1());
            //ThreadPool.QueueUserWorkItem(o => Starting_Task_When_Another_Completes.Func2());
            //Console.ReadKey();

            //TestAsyncAwaitMethods();
            //Console.WriteLine("Press any key to exit...");
            //Console.ReadLine();

            //-----------------------------------------------------------------------------------------------------------------------------------

            //Loader();

            //-----------------------------------------------------------Async------------------------------------------------------------------------

            async Task AsyncMethod()
            {
                await Task.Delay(2000);
                Console.WriteLine("Async Method");
            }

            void SyncMethod()
            {
                Console.WriteLine("Sync Method");
            }

            async Task CallerMethod()
            {
                await AsyncMethod();
                SyncMethod();
            }

            await CallerMethod();
            Console.ReadKey();

            //--------------------------------------------------------------Fibonacci---------------------------------------------------------------------

            //int FibonacciSeries(int n)
            //{
            //    if ((n == 0) || (n == 1))
            //    {
            //        return n;
            //    }

            //    var a = FibonacciSeries(n - 1) + FibonacciSeries(n - 2);
            //    return FibonacciSeries(n - 1) + FibonacciSeries(n - 2);
            //}

            //for (int i = 0; i <= 10; i++)
            //{
            //    Console.WriteLine(FibonacciSeries(i));
            //}

            //Console.WriteLine(FibonacciSeries(3));

            //-----------------------------------------------------------------------------------------------------------------------------------

            //int BalancePoint(int[] numbers)
            //{
            //    var totalSum = 0;
            //    var leftSum = 0;

            //    foreach (var number in numbers)
            //    {
            //        totalSum = totalSum + number;
            //    }

            //    for (int i = 0; i < numbers.Length; i++)
            //    {
            //        totalSum = totalSum - numbers[i];
            //        if (leftSum == totalSum)
            //        {
            //            return i;
            //        }
            //        leftSum = leftSum + numbers[i];
            //    }
            //    return -1;
            //}

            //int[] arr = { 2, 7, 4, 5, -3, 8, 9, -1 };
            //Console.WriteLine(BalancePoint(arr));

            //-----------------------------------------------------------------------------------------------------------------------------------

            //string JumbledString(string textToJumble)
            //{
            //    var stringList = textToJumble.ToLower().Split(' ');

            //    StringBuilder aaa = new StringBuilder();

            //    foreach (var stringItem in stringList)
            //    {
            //        char[] arr = stringItem.ToCharArray();
            //        Array.Sort(arr);
            //        aaa.Append(arr);
            //    }

            //    return aaa.ToString();
            //}

            //Console.WriteLine(JumbledString("The"));

            //-----------------------------------------------------------------------------------------------------------------------------------
        }
    }
}
