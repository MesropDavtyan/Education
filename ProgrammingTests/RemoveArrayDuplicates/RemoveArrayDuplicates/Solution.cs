using System.Collections.Generic;
using System.Linq;

namespace RemoveArrayDuplicates
{
    public class Solution
    {
        public int[] RemoveDuplicates(int[] arr)
        {
            var uniqueItems = new HashSet<int>();

            foreach (var item in arr)
            {
                uniqueItems.Add(item);
            }

            int[] newArr = uniqueItems.ToArray();

            return newArr;
        }
    }
}
