using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSplitter
{
    public class Solution
    {
        public int GetSplittingAmount(string S)
        {
            Dictionary<char, int> collection  = new Dictionary<char, int>();

            foreach (var item in S)
            {
                int count;

                if (collection.TryGetValue(item, out count))
                {
                    collection[item] = count + 1;
                }
                else
                {
                    collection[item] = 1;
                }
            }

            if (collection['a'] % 3 == 0 || collection['a'] == 1)
            {
                
            }

            return 0;
        }
    }
}
