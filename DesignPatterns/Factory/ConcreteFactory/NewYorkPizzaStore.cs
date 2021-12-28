﻿using Factory.Component;
using Factory.ConcreteComponent;
using Factory.Factory;
using System.Collections.Generic;

namespace Factory.ConcreteFactory
{
    public class NewYorkPizzaStore : PizzaStore
    {
        public override IPizza CreatePizza(IList<string> ingredients)
        {
            return new NewYorkPizza(ingredients);
        }
    }
}