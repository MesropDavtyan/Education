using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CroppedString
{
    public class Solution
    {
        public string StringCropper(string message, int charLimit)
        {
            string[] messageArr = message.Split(' ');
            StringBuilder messageBuilder = new StringBuilder();

            for (int i = 0; i < messageArr.Length; i++)
            {
                List<char> charList = messageArr[i].ToList();
                //charList.Add(' ');

                if (charList.Count <= charLimit)
                {
                    for (int k = 0; k < charList.Count; k++)
                    {
                        messageBuilder.Append(charList[k]);
                        charLimit--;

                        if (k == charList.Count - 1 && charLimit != 0 && charList[k] != ' ')
                        {
                            charList.Add(' ');
                        }
                    }
                }
            }

            //return messageBuilder.ToString().Trim();
            return messageBuilder.ToString();
        }
    }
}
