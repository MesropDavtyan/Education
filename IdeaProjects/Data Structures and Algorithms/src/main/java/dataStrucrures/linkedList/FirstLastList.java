package dataStrucrures.linkedList;

public class FirstLastList {
    private MyLink first;
    private MyLink last;

    public FirstLastList() {
        first = null;
        last = null;
    }

    public boolean IsEmpty() {
        return first == null;
    }

    public void insertFirst(double dd) {
        MyLink newLink = new MyLink(dd);

        if (IsEmpty()) {
            last = newLink;
        }

        newLink.next = first;
        first = newLink;
    }

    public void insertLast(int id, double dd) {
        MyLink newLink = new MyLink(dd);

        if (IsEmpty()) {
            first = newLink;
        } else {
            last.next = newLink;
        }
        last = newLink;
    }
    
    public double deleteFirst() {
        double temp = first.dData;
        if (first.next == null) {
            last = null;
        }
        first = first.next;
        return temp;
    }

    public void displayList() {
        System.out.print("List (first -> last): ");
        MyLink current = first;
        while(current != null) {
            current.displayLink();
            current = current.next;
        }
        System.out.println("");
    }
}
