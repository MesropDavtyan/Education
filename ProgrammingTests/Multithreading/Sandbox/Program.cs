using static Sandbox.Solution;

using System;
using System.Threading;
using System.Threading.Tasks;
namespace Sandbox;
class Program
{
    //static SemaphoreSlim sem = new SemaphoreSlim(5);

    //static void Enter(object id)
    //{
    //    Console.WriteLine(id + " wants to enter");
    //    sem.Wait();
    //    Console.WriteLine(id + " is in!");
    //    Thread.Sleep(1000 * (int)id);
    //    Console.WriteLine(id + " is leaving");
    //    sem.Release();
    //}
    private static Mutex mutex = new Mutex();
    private static Semaphore semaphore = new Semaphore(2, 3);
    private static SemaphoreSlim slim = new SemaphoreSlim(3);
    private static SemaphoreSlim slim2 = new SemaphoreSlim(0, 3);
    private static int padding;
    public static object locker = new object();

    public static void MutexDemo()
    {
        Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter Critical Section for processing");
        //if (mutex.WaitOne(15000))
        //{
        //    try
        //    {
        //        //Blocks the current thread until the current WaitOne method receives a signal.  
        //        //Wait until it is safe to enter. 
        //        Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Processing now");
        //        Thread.Sleep(2000);
        //        Console.WriteLine("Exit: " + Thread.CurrentThread.Name + " is Completed its task");
        //    }
        //    finally
        //    {
        //        //Call the ReleaseMutex method to unblock so that other threads
        //        //that are trying to gain ownership of the mutex can enter  
        //        mutex.ReleaseMutex();
        //        Console.WriteLine("Mutex is released");
        //    }
        //}

        mutex.WaitOne();
        Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Processing now");
        Thread.Sleep(2000);
        Console.WriteLine("Exit: " + Thread.CurrentThread.Name + " is Completed its task");
        mutex.ReleaseMutex();
        Console.WriteLine("Mutex is released");
    }

    public static void DoSomeTask()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} Wants to enter into Critical Section for processing");
        //try
        //{
        //    //Blocks the current thread until the current WaitHandle receives a signal.
        //    semaphore.WaitOne();
        //    //Blocks the current thread until the current WaitHandle receives a signal.
        //    Console.WriteLine($"Success: {Thread.CurrentThread.Name} is doing its work");
        //    Thread.Sleep(3000);
        //    Console.WriteLine($"{Thread.CurrentThread.Name} Exit.");
        //}
        //finally
        //{
        //    //Release() method to release semaphore  
        //    //Increase the Initial Count Variable by 1
        //    semaphore.Release();
        //}

        //Blocks the current thread until the current WaitHandle receives a signal.
        semaphore.WaitOne();
        //Blocks the current thread until the current WaitHandle receives a signal.
        Console.WriteLine($"Success: {Thread.CurrentThread.Name} is doing its work");
        Thread.Sleep(3000);
        Console.WriteLine($"{Thread.CurrentThread.Name} Exit.");
        //Release() method to release semaphore  
        //Increase the Initial Count Variable by 1
        semaphore.Release();
    }

    public static void SemaphoreSlimFunction(string name, int seconds)
    {
        Console.WriteLine($"{name} waits to access resource");
        slim.Wait();
        Console.WriteLine($"{name} was granted access to resource");

        Thread.Sleep(seconds);
        Console.WriteLine($"{name} has completed");
        slim.Release();
    }

    public async static Task SomeMethod()
    {
        Console.WriteLine("Some Method Started...");

        await Task.Delay(10000);

        Console.WriteLine("Some Method Ended.");
    }

    static int counter = 0;
    public static void LockTest()
    {
        lock (locker)
        {
            Console.WriteLine(counter++);
        }
    }

    static async Task Main(string[] args)
    {
        //================================================================================================================================

        //Foo myObj = new Foo();

        //Task.Run(() => myObj.First(() => Console.WriteLine("First")));
        //Task.Run(() => myObj.Second(() => Console.WriteLine("Second")));
        //Task.Run(() => myObj.Third(() => Console.WriteLine("Third")));

        //Console.ReadLine();

        //================================================================================================================================

        //task1.Wait();
        //task2.Wait();
        //task3.Wait();

        //Task test = task1.ContinueWith(t2 => task2.Start()).ContinueWith(t3 => task3.Start());

        //task1.Start();

        //Console.ReadLine();

        //================================================================================================================================

        //for (int i = 1; i <= 10; i++)
        //{
        //    int a = i;
        //    Task t = Task.Run(() => Enter(a));

        //    //new Thread(Enter).Start(i);
        //}

        //Console.ReadLine();


        //================================================================================================================================

        //for (int i = 1; i <= 5; i++)
        //{
        //    Thread threadObject = new Thread(MutexDemo)
        //    {
        //        Name = "Thread " + i
        //    };
        //    threadObject.Start();
        //}
        //Console.ReadKey();

        //================================================================================================================================

        //for (int i = 1; i <= 10; i++)
        //{
        //    Thread threadObject = new Thread(DoSomeTask)
        //    {
        //        Name = $"Thread {i}"
        //    };

        //    threadObject.Start();
        //}
        //Console.ReadKey();

        //================================================================================================================================

        //for (int i = 1; i <= 5; i++)
        //{
        //    int count = i;
        //    Thread t = new Thread(() => SemaphoreSlimFunction($"Thread {count}", 1000 * count));
        //    t.Start();
        //}
        //Console.ReadKey();

        //================================================================================================================================

        //Console.WriteLine($"{slim2.CurrentCount} tasks can enter the semaphore");
        //Task[] tasks = new Task[5];

        //for (int i = 0; i < 5; i++)
        //{
        //    tasks[i] = Task.Run(() =>
        //    {
        //        // Each task begins by requesting the semaphore.
        //        Console.WriteLine($"Task {Task.CurrentId} begins and waits for the semaphore");
        //        int semaphoreCount;
        //        slim2.Wait();
        //        try
        //        {
        //            Interlocked.Add(ref padding, 100);
        //            Console.WriteLine($"Task {Task.CurrentId} enters the semaphore");
        //            Thread.Sleep(1000 + padding);
        //        }
        //        finally
        //        {
        //            semaphoreCount = slim2.Release();
        //        }
        //        Console.WriteLine($"Task {Task.CurrentId} releases the semaphore, previous count: {semaphoreCount}");
        //    });
        //}

        //// Wait for one second, to allow all the tasks to start and block.
        //Thread.Sleep(1000);

        //// Restore the semaphore count to its maximum value
        //Console.WriteLine("Main thread calls Release(3) --> ");
        //slim2.Release(3);
        //Console.WriteLine($"{slim2.CurrentCount} tasks can enter the semaphore");

        //// Main thread waits for the tasks to complete.
        //Task.WaitAll(tasks);

        //Console.WriteLine("Main thread Exits");
        //Console.ReadKey();

        //================================================================================================================================

        //Solution solution = new Solution();

        //Task.Factory.StartNew(() => solution.PrintOdd());
        //Task.Factory.StartNew(() => solution.PrintEven());

        //Console.ReadKey();

        //================================================================================================================================

        //Console.WriteLine("Main Method Started...");

        //SomeMethod();

        //Console.WriteLine("Main Method Ended.");
        //Console.ReadKey();

        //================================================================================================================================

        //for (int i = 1; i <= 10; i++)
        //{
        //    Thread threadObject = new Thread(LockTest);

        //    threadObject.Start();
        //}
        //Console.ReadKey();

        //================================================================================================================================

        //Solution solution = new Solution();

        //Task.Run(() => solution.SubmitTask(new Task(() => Console.WriteLine("Before Trigger 1"))));
        //Task.Run(() => solution.SubmitTask(new Task(() => Console.WriteLine("Before Trigger 2"))));
        //Task.Run(() => solution.SubmitTask(new Task(() => Console.WriteLine("Before Trigger 3"))));
        //Task.Run(() => solution.Trigger());
        //Task.Run(() => solution.SubmitTask(new Task(() => Console.WriteLine("After Trigger 1"))));
        //Task.Run(() => solution.SubmitTask(new Task(() => Console.WriteLine("After Trigger 2"))));

        //Console.ReadKey();

        Task.Delay(5000).ContinueWith(t => Console.WriteLine(42));

        Console.ReadKey();
    }
}