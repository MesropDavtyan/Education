package dataStrucrures.linkedList;

public class MyDoubleLink {
    public double dData;
    public MyDoubleLink next;
    public MyDoubleLink previous;

    public MyDoubleLink(double d) {
        dData = d;
    }

    public void displayLink() {
        System.out.print(dData + " ");
    }
}
