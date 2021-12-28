package dataStrucrures.linkedList;

public class MyLink {
    public double dData;
    public MyLink next;

    public MyLink(double dd){
        dData = dd;
    }

    public void displayLink(){
        System.out.printf("{ %f%n }", dData);
    }
}
