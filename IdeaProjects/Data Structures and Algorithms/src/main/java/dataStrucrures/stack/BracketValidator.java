package dataStrucrures.stack;

import java.util.HashMap;

public class BracketValidator {
    public static boolean isValid(String input) {
        if (input.length() == 1) {
            return false;
        }

        HashMap<Character, Character> brackets = new HashMap<>();
        brackets.put('(',')');
        brackets.put('{','}');
        brackets.put('[',']');
        brackets.put('<','>');

        MyStack theStack = new MyStack(input.length());

        for (int i = 0; i < input.length(); i++) {
            if (brackets.containsKey(input.charAt(i))) {
                theStack.push(input.charAt(i));
            }
            else {
                if (theStack.isEmpty() || brackets.get(theStack.peek()) != input.charAt(i)) {
                    return false;
                }
                theStack.pop();
            }
        }

        return theStack.isEmpty();
    }
}
