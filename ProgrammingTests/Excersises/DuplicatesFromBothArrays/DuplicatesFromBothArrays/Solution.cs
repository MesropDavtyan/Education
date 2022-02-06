using System.Collections.Generic;

namespace DuplicatesFromBothArrays
{
    public class Solution
    {
        public List<string> FindDuplicates(string[] first, string[] second)
        {
            List<string> duplicates = new List<string>();
            Dictionary<string, bool> dict = new Dictionary<string, bool>();

            for (int i = 0; i < first.Length; i++)
            {
                dict.Add(first[i], false);
            }

            for (int i = 0; i < second.Length; i++)
            {
                if (dict.TryGetValue(second[i], out _))
                {
                    dict[second[i]] = true;
                }
            }

            foreach (var item in dict)
            {
                if (item.Value == true)
                {
                    duplicates.Add(item.Key);
                }
            }

            return duplicates;
        }
    }
}
