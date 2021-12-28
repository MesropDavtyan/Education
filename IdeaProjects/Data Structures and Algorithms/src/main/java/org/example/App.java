package org.example;

public class App 
{
    public static void main( String[] args )
    {
        //----------------- Sorting --------------------

        /*int[] toSort = new int[]{5, 1, 2, 89, 7, 5};

        int[] arr = SelectionSort.sort(toSort);

        for(int item : arr){
            System.out.println(item);
        }*/

        //----------------- Stack --------------------

        /*String str = Reverser.doRev("Qrists");

        for (int i = 0; i < str.length(); i++) {
            System.out.print(str.charAt(i));
        }*/

        //--------------------------------------------

        //System.out.println(BracketValidator.isValid("(asdasdas])"));


        /*MyQueue.Enqueue(1);
        MyQueue.Enqueue(2);
        MyQueue.Enqueue(3);
        MyQueue.Enqueue(4);

        MyQueue.Dequeue();
        MyQueue.Dequeue();

        System.out.println(MyQueue.head.data);*/

        /*MyLinkedList myList = new MyLinkedList();

        myList.insert(22, 2.99);
        myList.insert(44, 2.99);
        myList.insert(66, 2.99);
        myList.insert(88, 2.99);
        //myList.insertAfter(44, 55, 3.89);

        myList.displayList();*/

        //System.out.println(myList.delete(88).iData);
        //System.out.println(myList.delete(55).iData);

        //System.out.println(myList.deleteHead().iData);

        /*while(!myList.isEmpty()) {
            MyLink myLink = myList.deleteHead();
            System.out.printf("Deleted ");
            myLink.displayLink();
            System.out.println("");
        }*/
        //myList.displayList();

        /*FirstLastList flList = new FirstLastList();

        flList.insertFirst(0,22);
        flList.insertFirst(0,44);
        flList.insertFirst(0,66);

        flList.insertLast(0,11);
        flList.insertLast(0,33);
        flList.insertLast(0,55);

        flList.displayList();

        flList.deleteFirst();
        flList.deleteFirst();

        flList.displayList();*/

       /* LinkStack myLinkStack = new LinkStack();

        myLinkStack.push(0,20);
        myLinkStack.push(0, 40);

        myLinkStack.displayStack();

        myLinkStack.push(0,60);
        myLinkStack.push(0, 80);

        myLinkStack.displayStack();

        myLinkStack.pop();
        myLinkStack.pop();

        myLinkStack.displayStack();*/

        /*LinkQueue linkQueue = new LinkQueue();

        linkQueue.enqueue(20);
        linkQueue.enqueue(40);

        linkQueue.displayQueue();

        linkQueue.enqueue(60);
        linkQueue.enqueue(80);

        linkQueue.displayQueue();

        linkQueue.dequeue();
        linkQueue.dequeue();

        linkQueue.displayQueue();*/

        /*MySortedList theSortedList = new MySortedList();
        theSortedList.insert(20); // insert 2 items
        theSortedList.insert(40);
        theSortedList.displayList(); // display list
        theSortedList.insert(10); // insert 3 more items
        theSortedList.insert(30);
        theSortedList.insert(50);
        theSortedList.displayList(); // display list
        theSortedList.remove(); // remove an item
        theSortedList.displayList(); // display list*/

        /*MyDoublyLinkedList theList = new MyDoublyLinkedList();
        theList.insertFirst(22); // insert at front
        theList.insertFirst(44);
        theList.insertFirst(66);
        theList.insertLast(11); // insert at rear
        theList.insertLast(33);
        theList.insertLast(55);
        theList.displayForward(); // display list forward
        theList.displayBackward(); // display list backward
        theList.deleteFirst(); // delete first item
        theList.deleteLast(); // delete last item
        theList.deleteKey(11); // delete item with key 11
        theList.displayForward(); // display list forward
        theList.insertAfter(22, 77); // insert 77 after 22
        theList.insertAfter(33, 88); // insert 88 after 33
        theList.displayForward(); // display list forward*/
    }
}
