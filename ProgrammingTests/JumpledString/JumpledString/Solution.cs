using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JumpledString
{
    //public enum MyEnum
    //{
    //    ,
    //}

    public class Solution
    {
        public string JumbleSentence(string input)
        {
            var jumbledSentance = new StringBuilder();

            foreach (var item in input.Split(' '))
            {
                jumbledSentance.Append(SortingText(item) + ' ');
            }
            return jumbledSentance.ToString().TrimEnd();
        }

        public static string SortingText(string word)
        {
            List<char> letters = new List<char>();
            for (int index = 0; index < word.Length; index++)
            {
                if (char.IsLetter(word[index]))
                {
                    letters.Add(char.ToLower(word[index])); 
                }
            }

            var lettersArray = letters.ToArray();
            Array.Sort(lettersArray);
            //letters = SortLetters(letters);

            StringBuilder result = new StringBuilder();
            int characterIndex = 0;

            foreach (var currentLetter in word.ToCharArray())
            {
                if (char.IsUpper(currentLetter))
                {
                    result.Append(char.ToUpper(lettersArray[characterIndex]));
                    characterIndex++;
                }
                else if (char.IsLower(currentLetter))
                {
                    result.Append(char.ToLower(lettersArray[characterIndex]));
                    characterIndex++;
                }
                else
                {
                    result.Append(currentLetter);
                }
            }

            return result.ToString();
        }


        //public static List<char> SortLetters(List<char> letters)
        //{
        //    int[] lets = new int[256];
        //    foreach (var character in letters)
        //    {
        //        lets[character]++;
        //    }

        //    List<char> finalLetters = new List<char>();
        //    int index = 0;
        //    for (int i = 0; i < 256; i++)
        //    {
        //        if (lets[i] > 0)
        //        {
        //            while (lets[i] > 0)
        //            {
        //                finalLetters.Add((char)i);
        //                index++;
        //                lets[i]--;
        //            }
        //        }
        //    }
        //    return finalLetters;
        //}
    }
}
