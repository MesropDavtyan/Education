using Startegy.ConcreteStrategy;
using Startegy.Context;
using Startegy.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startegy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("Babken");
            list.Add("David");
            list.Add("Narek");

            SortedList studentsList = new SortedList();

            studentsList.SetSortStrategy(new QuickSort());
            studentsList.Sort(list);

            studentsList.SetSortStrategy(new MergeSort());
            studentsList.Sort(list);

            studentsList.SetSortStrategy(new ShellSort());
            studentsList.Sort(list);
        }
    }
}
