﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startegy.Strategy
{
    public abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }
}
