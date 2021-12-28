package dataStrucrures.linkedList;

public class MyLinkedList {
    private MyLink head;
    private MyLink tail;

    public MyLinkedList(){
        head = tail = null;
    }

    public boolean isEmpty() {
        return (head == null);
    }

    public void insert(double dd) {
        MyLink myLink = new MyLink(dd);
        if(head == null) {
            head = myLink;
            tail = head;
        } else {
            tail.next = myLink;
            tail = myLink;
        }
    }

    public void insertHead(double dd) {
        MyLink myLink = new MyLink(dd);
        myLink.next = head;
        head = myLink;
    }

    public void insertAfter(int key, int id, double dd) {
        MyLink myLink = new MyLink(dd);

        MyLink current = find(key);

        if(current != null){
            myLink.next = current.next;
            current.next = myLink;
        }
    }

    public MyLink find(double key) {
        MyLink current = head;

        while(current.dData != key) {
            if(current.next != null) {
                current = current.next;
            } else {
                return null;
            }
        }
 
        return current;
    }

    public MyLink delete(double key) {
        MyLink current = head;
        MyLink previous = head;

        while(current.dData != key) {
            if(current.next != null) {
                previous = current;
                current = current.next;
            } else {
                return null;
            }
        }

        if(current == head) {
            current = head.next;
        } else {
            previous.next = current.next;
        }

        return current;
    }

    public MyLink deleteHead() {
        MyLink current = head;
        head = head.next;
        return current;
    }

    public void displayList() {
        System.out.print("List (first --> last): ");
        MyLink current = head;
        while(current != null) {
            current.displayLink();
            current = current.next;
        }
        System.out.println("");
    }
}
