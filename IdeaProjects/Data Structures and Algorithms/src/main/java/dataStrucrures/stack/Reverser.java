package dataStrucrures.stack;

public class Reverser {
    private static String output = "";

    public static String doRev(String input) {
        MyStack theStack = new MyStack(input.length());

        for (int i = 0; i < input.length(); i++) {
            char character = input.charAt(i);
            theStack.push(character);
        }

        while (!theStack.isEmpty()) {
            output = output + theStack.pop();
        }

        return output;
    }
}
