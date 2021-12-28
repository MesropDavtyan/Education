using System.Collections.Generic;

namespace Factory.Component
{
    public abstract class Pizza : IPizza
    {
        protected Pizza(IList<string> ingredients)
        {
            Toppings = ingredients;
        }
        public IList<string> Toppings { get; }

        public DoughType Dough { get; set; }
        public string Seasonings { get; set; }
        public string SauceType { get; set; }

        public abstract void Bake();

        public abstract void Box();

        public abstract void Cut();
    }
}
