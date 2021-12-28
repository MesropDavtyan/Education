using System;
using System.Collections.Generic;

namespace RomanToNumber
{
    public class Solution
    {
        private int Value(char letter)
        {
            switch (char.ToUpper(letter))
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    throw new Exception("Wrong roman number");
            }
        }

        public int RomanToNumber(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int current = Value(input[i]);
                if (i < input.Length - 1)
                {
                    int next = Value(input[i + 1]);
                    if (current >= next)
                    {
                        sum = sum + current;
                    }
                    else
                    {
                        sum = sum + next - current;
                        i++;
                    }
                }
                else
                {
                    sum = sum + current;
                    i++;
                }
            }
            return sum;
        }

        public int RomanToInteger(string roman)
        {
            int number = 0;
            Dictionary<char, int> romanCollection = new Dictionary<char, int>
            {
                {'I', 1 },
                {'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000 }
            };

            if (roman.Length == 1)
            {
                return romanCollection[roman[0]];
            }

            for (int i = 0; i < roman.Length; i++)
            {
                if (i < roman.Length - 1)
                {
                    if (romanCollection[roman[i]] < romanCollection[roman[i + 1]])
                    {
                        number -= romanCollection[roman[i]];
                    }
                    else
                    {
                        number += romanCollection[roman[i]];
                    }
                }
                else if (i == roman.Length - 1)
                {
                    number += romanCollection[roman[i]];
                }

            }

            return number;
        }
    }
}
