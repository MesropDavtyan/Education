using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayIntersections
{
    public class Solution
    {
        public int[] GetIntersect(int[] first, int[] second)
        {
            List<int> intersections = new List<int>();
            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < first.Length; i++)
            {
                if (dict.TryGetValue(first[i], out int result))
                {
                    result++;
                }
                else
                {
                    dict.Add(first[i], 1);
                }
            }

            for (int j = 0; j < second.Length; j++)
            {
                if (dict.TryGetValue(second[j], out int result))
                {
                    if (result >= 1)
                    {
                        intersections.Add(second[j]);
                        result--;
                    }
                }
            }

            return intersections.ToArray();
        }
    }
}
