using System;
using System.Text;

namespace ReverseWords
{
    public class Solution
    {
        public string ReverseWordsNotOptimal(string text)
        {
            var jumbledSentance = new StringBuilder();

            string[] words = text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

            for (int i = words.Length - 1; i >= 0; i--)
            {
                jumbledSentance.Append(words[i] + ' ');
            }

            return jumbledSentance.ToString().TrimEnd();
        }

        //public string ReverseText(string text)
        //{
        //    var jumbledSentance = new StringBuilder(text);
        //    var lastIndex = text.Length - 1;

        //    //string[] words = text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);

        //    for (int i = 0; i < text.Length / 2; i++)
        //    {
        //        jumbledSentance[i] = text[lastIndex - i];
        //        jumbledSentance[lastIndex - i] = text[i];
        //    }

        //    return jumbledSentance.ToString();
        //}

        public string ReverseWordsOptimal(string text)
        {
            //var jumbledSentance = new StringBuilder();

            string[] words = text.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            var lastIndex = words.Length - 1;

            for (int i = 0; i < words.Length / 2; i++)
            {
                var temp = words[lastIndex - i];
                words[lastIndex - i] = words[i];
                words[i] = temp;
            }

            //for (int i = 0; i < words.Length; i++)
            //{
            //    if (i != words.Length - 1)
            //    {
            //        jumbledSentance.Append(words[i] + " ");
            //    }
            //    else
            //    {
            //        jumbledSentance.Append(words[i]);
            //    }
            //}

            //return jumbledSentance.ToString();
            return string.Join(" ", words).TrimEnd();
        }

        public string ReverseWords(string text)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                {
                    continue;
                }

                int start = i;

                while (i < text.Length && text[i] != ' ')
                {
                    i++;
                }

                if (result.Length == 0)
                {
                    result.Insert(0, text.Substring(start, i - start));
                }
                else
                {
                    result.Insert(0, ' ').Insert(0, text.Substring(start, i - start));
                }
            }

            return result.ToString();
        } 
    }
}
