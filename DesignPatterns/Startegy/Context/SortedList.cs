using Startegy.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startegy.Context
{
    public class SortedList
    {
        private SortStrategy _sortStrategy;

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public void Sort(List<string> list)
        {
            _sortStrategy.Sort(list);
        }
    }
}
