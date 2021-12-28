using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovelyNumber
{
    public class Solution
    {
        public int LovelyNumCounter(int first, int last)
        {
            var globalCounter = 0;
            char[] numArr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            List<int> numList = new List<int>();
            for (int i = first; i <= last; i++)
            {
                numList.Add(i);
            }


            for (int i = 0; i < numList.Count; i++)
            {
                char[] paramArr = numList[i].ToString().ToArray();
                globalCounter++;

                for (int j = 0; j < numArr.Length; j++)
                {
                    var counter = 0;

                    for (int k = 0; k < paramArr.Length; k++)
                    {

                        if (numArr[j] == paramArr[k])
                        {
                            counter++;
                        }

                        if (counter >= 3 && globalCounter > 0)
                        {
                            globalCounter--;
                        }
                    }

                }
            }

            return globalCounter;
        }
    }
}
