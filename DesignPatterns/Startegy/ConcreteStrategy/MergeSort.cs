using Startegy.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startegy.ConcreteStrategy
{
    public class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.MergerSort(); not-implemented
            list.Sort();
            Console.WriteLine("MergeSorted List ");
            foreach (var listItem in list)
            {
                Console.WriteLine(listItem);
            }
            Console.WriteLine();
        }
    }
}
