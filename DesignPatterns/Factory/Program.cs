﻿using Factory.ConcreteFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizza = new NewYorkPizzaStore().OrderPizza(new List<string>());
        }
    }
}
