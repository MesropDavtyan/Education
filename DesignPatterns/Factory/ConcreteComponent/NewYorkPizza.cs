using Factory.Component;
using System.Collections.Generic;

namespace Factory.ConcreteComponent
{
    public class NewYorkPizza : Pizza
    {
        public NewYorkPizza(IList<string> ingredients):base(ingredients)
        {
            Dough = DoughType.Thin;
        }

        public override void Bake()
        {
        }

        public override void Box()
        {
        }

        public override void Cut()
        {
        }
    }
}
