using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLinkedList
{
    public class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }

    public class LinkedListQueue
    {
        Node front;
        Node rear;

        public LinkedListQueue()
        {
            front = rear = null;
        }

        public void Enqueue(int item)
        {
            Node newNode = new Node(item);

            if (rear == null)
            {
                rear = front = newNode;
            }
            else
            {
                rear.next = newNode;
                rear = newNode;
            }
        }

        public void Dequeue()
        {
            front = front.next;

            if (front == null)
            {
                rear = null;
            }
        }
    }
}
