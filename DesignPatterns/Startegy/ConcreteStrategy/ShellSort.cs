using Startegy.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startegy.ConcreteStrategy
{
    public class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            //list.ShellSort(); not-implemented
            list.Sort();
            Console.WriteLine("ShellSorted List ");
            foreach (var listItem in list)
            {
                Console.WriteLine(listItem);
            }
            Console.WriteLine();
        }
    }
}
