using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitCounter
{
    public class Solution
    {
        public int BitSummer(int number)
        {
            int counter = 0;
            while (number > 0)
            {
                counter += number & 1;
                number >>= 1;
            }
            return counter;
        }

        public async Task FooAsync()
        {
            Stack<int> myStack = new Stack<int>();

            await Task.Factory.StartNew(() => PopulateStack(myStack));
            //Task.Factory.StartNew(() => UseStack(myStack, "A"));
            //Task.Factory.StartNew(() => UseStack(myStack, "B"));
            //Task.Factory.StartNew(() => UseStack(myStack, "C"));

            Console.WriteLine("End of method");
        }

        public async Task PopulateStack(Stack<int> myStack)
        {
            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
            }
        }

        public void UseStack(Stack<int> myStack, string character)
        {
            myStack.Pop();
            Console.WriteLine("{0},{1}", myStack, character);
        }

    }
}
