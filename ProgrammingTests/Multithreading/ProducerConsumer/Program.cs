using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            Solution solution = new Solution(queue);

            List<Task> taskList = new List<Task>();

            CancellationTokenSource ct = new CancellationTokenSource();

            taskList.Add(Task.Run(() => solution.Produce(1)));
            taskList.Add(Task.Run(() => solution.Consume()));
            taskList.Add(Task.Run(() => solution.Consume()));
            taskList.Add(Task.Run(() => solution.Consume()));
            taskList.Add(Task.Run(() => solution.Produce(2)));
            taskList.Add(Task.Run(() => solution.Produce(3)));
            taskList.Add(Task.Run(() => solution.Produce(4)));
            taskList.Add(Task.Run(() => solution.Consume()));
            taskList.Add(Task.Run(() => solution.Consume()));
            taskList.Add(Task.Run(() => solution.Produce(5)));
            taskList.Add(Task.Run(() => solution.Produce(6)));
            taskList.Add(Task.Run(() => solution.Consume()));
            taskList.Add(Task.Run(() => solution.Consume()));

            Console.ReadKey();
            ct.Cancel();

            try
            {
                Task.WaitAll(taskList.ToArray(), ct.Token);
            }
            catch (OperationCanceledException)
            {

                Console.WriteLine("Operation was canceled.");
            }
        }
    }
}
