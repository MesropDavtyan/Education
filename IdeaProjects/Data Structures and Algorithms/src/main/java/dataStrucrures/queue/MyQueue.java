package dataStrucrures.queue;

public class MyQueue {
    public static Node head;
    public static Node tail;

    public MyQueue() {
        head = tail = null;
    }

    public static void Enqueue(int data) {
        Node newNode = new Node(data);

        if (tail == null) {
            head = tail = newNode;
        }
        else
        {
            tail.next = newNode;
            tail = newNode;
        }
    }

    public static void Dequeue() {
        head = head.next;

        if (head == null) {
            tail = null;
        }
    }
}
