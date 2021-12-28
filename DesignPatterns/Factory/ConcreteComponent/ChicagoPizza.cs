using Factory.Component;
using System.Collections.Generic;

namespace Factory.ConcreteComponent
{
    public class ChicagoPizza : Pizza
    {
        public ChicagoPizza(IList<string> ingridients) : base(ingridients)
        {
            Dough = DoughType.Pan;
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
