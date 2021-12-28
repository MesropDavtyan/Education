package dataStrucrures.stack;

public class MyStack {
    private int maxSize;
    private char[] stackArray;
    private int top;

    public MyStack(int size) {
        maxSize = size;
        stackArray = new char[maxSize];
        top = -1;
    }

    public void push(char item) {
        if (top < maxSize) {
            stackArray[++top] = item;
        }
        else {
            System.out.println("Stack is full");
        }
    }

    public char pop() {
        return stackArray[top--];
    }

    public char peek() {
        return stackArray[top];
    }

    public boolean isEmpty() {
        return top == -1;
    }
}
