using System;

namespace DuplicatesFromBothArrays
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Solution solution = new Solution();

            var duplicates = solution.FindDuplicates(new string[] { "Darth Vader", "Anakin Skywalker", "Venom", "Bobba Fett" }, new string[] { "Carnage", "Thanos", "Bobba Fett", "Spider Man", "Darth Vader", "Venom" });

            foreach (var duplicate in duplicates)
            {
                Console.WriteLine(duplicate);
            }
        }
    }
}
