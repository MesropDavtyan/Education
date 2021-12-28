package dataStrucrures.linkedList;

public class MyDoublyLinkedList {
    private MyDoubleLink first;
    private MyDoubleLink last;

    public MyDoublyLinkedList() {
        first = null;
        last = null;
    }

    public boolean isEmpty() {
        return first == null;
    }

    public void insertFirst(double dd) {
        MyDoubleLink newLink = new MyDoubleLink(dd);

        if(isEmpty()) {
            last = newLink;
        } else {
            first.previous = newLink;
        }
        newLink.next = first;
        first = newLink;
    }

    public void insertLast(double dd) {
        MyDoubleLink newLink = new MyDoubleLink(dd);

        if(isEmpty()) {
            first = newLink;
        } else {
            last.next = newLink;
        }
        newLink.previous = last;
        last = newLink;
    }

    public MyDoubleLink deleteFirst() {
        MyDoubleLink temp = first;

        if(first.next == null) {
            last = null;
        } else {
            first.next.previous = null;
        }
        first = first.next;
        return temp;
    }

    public MyDoubleLink deleteLast() {
        MyDoubleLink temp = last;

        if(first.next == null) {
            first = null;
        } else {
            last.previous.next = null;
        }
        last = last.previous;
        return temp;
    }

    public boolean insertAfter(double key, double dd) {
        MyDoubleLink current = first;

        while(current.dData != key) {
            current = current.next;
            if(current == null) {
                return false;
            }
        }

        MyDoubleLink newLink = new MyDoubleLink(dd);

        if(current == last) {
            newLink.next = null;
            last = newLink;
        } else {
            newLink.next = current.next;
            current.next.previous = newLink;
        }
        newLink.previous = current;
        current.next = newLink;

        return true;
    }

    public MyDoubleLink deleteKey(double key) {
        MyDoubleLink current = first;

        while(current.dData != key) {
            current = current.next;
            if(current.next == null) {
                return null;
            }
        }

        if(current == first) {
            first = current.next;
        } else {
            current.previous.next = current.next;
        }

        if(current == last) {
            last = current.previous;
        } else {
            current.next.previous = current.previous;
        }

        return current;
    }

    public void displayForward() {
        System.out.print("List (first -> last): ");
        MyDoubleLink current = first;

        while(current != null) {
            current.displayLink();
            current = current.next;
        }

        System.out.println("");
    }

    public void displayBackward() {
        System.out.print("List (last -> first): ");
        MyDoubleLink current = last;

        while(current != null) {
            current.displayLink();
            current = current.previous;
        }

        System.out.println("");
    }
}
