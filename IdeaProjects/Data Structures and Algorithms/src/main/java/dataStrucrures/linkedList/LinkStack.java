package dataStrucrures.linkedList;

public class LinkStack {
    private MyLinkedList myList;

    public LinkStack(){
        myList = new MyLinkedList();
    }

    public void push(int id, double dd) {
        myList.insertHead(dd);
    }

    public MyLink pop() {
        return myList.deleteHead();
    }

    public void displayStack() {
        System.out.print("Stack (top --> bottom): ");
        myList.displayList();
    }
}
