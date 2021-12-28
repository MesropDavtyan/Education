package dataStrucrures.linkedList;

public class LinkQueue {
    private FirstLastList myList;

    public LinkQueue() {
        myList = new FirstLastList();
    }

    public boolean isEmpty() {
        return myList.IsEmpty();
    }

    public void enqueue(double dd) {
        myList.insertLast(0, dd);
    }

    public double dequeue() {
        return myList.deleteFirst();
    }

    public void displayQueue() {
        System.out.print("Queue (front --> rear): ");
        myList.displayList();
    }
}
