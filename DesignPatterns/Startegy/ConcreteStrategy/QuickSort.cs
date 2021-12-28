using Startegy.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startegy.ConcreteStrategy
{
    public class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            // Default is QuickSort
            list.Sort();
            Console.WriteLine("QuickSorted List");
            foreach (var listItem in list)
            {
                Console.WriteLine(listItem);
            }
            Console.WriteLine();
        }
    }
}
