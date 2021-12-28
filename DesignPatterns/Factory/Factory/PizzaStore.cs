using Factory.Component;
using System.Collections.Generic;

namespace Factory.Factory
{
    public abstract class PizzaStore
    {
        public IPizza OrderPizza(IList<string> ingredients)
        {
            IPizza pizza = CreatePizza(ingredients);
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }
        public abstract IPizza CreatePizza(IList<string> ingredients);
    }
}
