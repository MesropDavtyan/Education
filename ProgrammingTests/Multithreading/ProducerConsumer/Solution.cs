using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/*
   Unes mi hat Queue(trade safe chi)
   u unes multythreaded Producerner u Consumerner
   Producernerd et Queuei mej data en grelu consumerner@ kardan
   petqa wrapper gres et Queuei hamar vor multythreading@ apahoves
   bayc es keter@ petqa hashvi arnes
	1) ete produser thread@ galis tenuma queue -n liqna inq@ lrvuma u enqana spasum minchev queueum tex azatvi
	2) ete consumer thread@ tesnuma vor Queueun datarka enqana spasum minchev queueum ban gren 
*/

namespace ProducerConsumer
{
    public class Solution
    {
        AutoResetEvent resetEnqueue = new AutoResetEvent(false);
        AutoResetEvent resetDequeue = new AutoResetEvent(false);

        private Queue<int> queue;
        object obj1 = new object();
        object obj2 = new object();

        public Solution(Queue<int> queue)
        {
            this.queue = queue;
        }

        public void CustomEnqueue(int number)
        {
            queue.Enqueue(number);
            Console.WriteLine("Number added: {0}. Size of queue is {1}.", number, queue.Count);
            resetDequeue.Set();
        }

        public void CustomDequeue()
        {
            Console.WriteLine("Number removed: {0}", queue.Dequeue());
            resetEnqueue.Set();
        }

        public void Produce(int number)
        {
            lock (obj1)
            {
                if (queue.Count < 5)
                {
                    CustomEnqueue(number);
                }
                else
                {
                    Console.WriteLine("Queue is full");
                    resetEnqueue.WaitOne();
                    CustomEnqueue(number);
                }
            }
        }

        public void Consume()
        {
            lock (obj2)
            {
                if (queue.Count > 0)
                {
                    CustomDequeue();
                }
                else
                {
                    Console.WriteLine("Queue is empty");
                    while (queue.Count == 0)
                    {
                        resetDequeue.WaitOne();
                    }
                    CustomDequeue();
                }
            }
        }
    }


    public class Solution2
    {
        private Queue<int> queue;
        object obj1 = new object();
        object obj2 = new object();

        public Solution2(Queue<int> queue)
        {
            this.queue = queue;
        }

        public void CustomEnqueue(int number)
        {
            queue.Enqueue(number);
            Console.WriteLine("Number added: {0}. Size of queue is {1}.", number, queue.Count);
        }

        public void CustomDequeue()
        {
            Console.WriteLine("Number removed: {0}", queue.Dequeue());
        }

        public void Produce(int number)
        {
            lock (obj1)
            {
                while (queue.Count >= 5)
                {

                }
                CustomEnqueue(number);
            }
        }

        public void Consume()
        {
            lock (obj2)
            {
                while (queue.Count == 0)
                {

                }

                CustomDequeue();
            }
        }
    }
}
