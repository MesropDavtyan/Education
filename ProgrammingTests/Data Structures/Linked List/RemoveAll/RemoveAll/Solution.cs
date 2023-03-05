using System;
using System.Collections;
using System.Text;

namespace RemoveAll
{
    public class CustomComparer : IComparer<int>
    {
        public int Compare(int current, int next)
        {
            if (current < next)
            {
                return 1; // swap current and next
            }
            if (current > next)
            {
                return -1; // don't swap
            }
            else
            {
                return 0; // retain (current == next)
            }
        }
    }

    public class Solution
	{
        public void FindDoublesInList(List<int> values)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            List<int> myList = new List<int>();

            foreach (var value in values)
            {
                if (dict.ContainsKey(value))
                {
                    dict[value]++;
                }
                else
                {
                    dict.Add(value, 1);
                }
            }

            foreach (var value in values)
            {
                if (dict.ContainsKey(value * 2) && dict[value * 2] == 1)
                {
                    myList.Add(value);
                }
            }

            myList.Sort();

            Console.WriteLine(String.Join(' ', myList));
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void PrintClassification(List<List<int>> rawData)
        {
            Dictionary<int, int> points = new Dictionary<int, int>{ { 1, 10 }, { 2, 6 }, { 3, 4 }, { 4, 3 }, { 5, 2 }, { 6, 1 } };
            Dictionary<int, int> winners = new Dictionary<int, int>();
            List<int> loosers = new List<int>();

            rawData = rawData.OrderBy(d => d[1]).ToList();

            foreach (var item in rawData)
            {
                int racerName = item[1];
                int position = item[2];

                if(winners.ContainsKey(racerName)){
                    if (points.ContainsKey(position))
                    {
                        winners[racerName] += points[position];
                    }
                    else
                    {
                        loosers.Add(racerName);
                    }
                }
                else
                {
                    if (points.ContainsKey(position))
                    {
                        winners.Add(racerName, points[position]);
                    }
                    else
                    {
                        loosers.Add(racerName);
                    }
                }
            }

            KeyValuePair<int, int> winner = winners.Aggregate((l, r) => l.Value > r.Value ? l : r);

            Console.WriteLine($"{winner.Key} {winner.Value}");
            Console.WriteLine(string.Join(',', loosers));
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int CountPairs(List<int> array, int diff)
        {
            int pairs = 0;
            int len = array.Count;
            int i = 0;
            int j = 0;

            //array = array.OrderByDescending(i => i).ToList();
            array.Sort(new CustomComparer());

            while (j < len - 1)
            {
                for (i = j + 1;  i < len; ++i)
                {
                    if (array[j] == array[i] + diff)
                    {
                        pairs++;
                    }
                }
                j++;
            }

            return pairs;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int MaxRepeated(string short_s, string long_s)
        {
            if (string.IsNullOrEmpty(short_s) || string.IsNullOrEmpty(long_s))
            {
                return 0;
            }

            int maxCount = 0;
            int count = 0;
            int j = 0;
            for (int i = 0; i < long_s.Length; i++)
            {
                if (long_s[i] == short_s[j])
                {
                    j++;
                    if (j == short_s.Length)
                    {
                        count++;
                        j = 0;
                    }
                }
                else
                {
                    maxCount = Math.Max(maxCount, count);
                    count = 0;
                    j = 0;
                }
            }

            return Math.Max(maxCount, count);
        }
    }
}

