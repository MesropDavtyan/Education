using Factory.Component;
using System.Collections.Generic;

namespace Factory.ConcreteComponent
{
    public class CaliforniaPizza : Pizza
    {
        public CaliforniaPizza(IList<string> ingredients) : base(ingredients)
        {
            Dough = DoughType.None;
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
