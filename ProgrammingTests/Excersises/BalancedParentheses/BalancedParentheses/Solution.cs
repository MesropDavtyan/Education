using System.Collections;
using System.Collections.Generic;

namespace BalancedParentheses
{
    public class Solution
    {
        public bool ValidateParentheses(string text)
        {
            if (text.Length == 1)
            {
                return false;
            }

            Dictionary<char, char> parenthesesTypes = new Dictionary<char, char> { 
                { '(' , ')' },
                { '{' , '}' },
                { '[' , ']' },
                { '<' , '>' }
            };
            Stack parenthesesStack = new Stack();

            foreach (var letter in text)
            {
                if (parenthesesTypes.TryGetValue(letter, out _))
                {
                    parenthesesStack.Push(letter);
                }
                else if (parenthesesStack.Count != 0 && parenthesesTypes[(char)parenthesesStack.Peek()] == letter)
                {
                    parenthesesStack.Pop();
                }
                else if (parenthesesTypes.ContainsValue(letter))
                {
                    return false;
                }
            }
            if (parenthesesStack.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}
