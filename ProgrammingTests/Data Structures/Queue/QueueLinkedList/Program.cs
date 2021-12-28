using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListQueue myQueue = new LinkedListQueue();

            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);

            myQueue.Dequeue();
            myQueue.Dequeue();
        }
    }
}
