package dataStrucrures.linkedList;

public class MySortedList {
    private MyLink head;

    public  MySortedList() {
        head = null;
    }

    public boolean isEmpty() {
        return head == null;
    }

    public void insert(double key) {
        MyLink newLink = new MyLink(key);
        MyLink previous = null;
        MyLink current = head;

        while (current != null && key > current.dData) {
            previous = current;
            current = current.next;
        }

        if (previous == null) {
            head = newLink;
        } else {
            previous.next = newLink;
        }

        newLink.next = current;
    }

    public MyLink remove() {
        MyLink itemToRemove = head;
        head = head.next;
        return itemToRemove;
    }

    public void displayList() {
        System.out.print("List (first --> last): ");
        MyLink current = head;

        while (current != null) {
            current.displayLink();
            current = current.next;
        }

        System.out.println("");
    }
}
