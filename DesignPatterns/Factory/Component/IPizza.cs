using System.Collections.Generic;

namespace Factory.Component
{
    public interface IPizza
    {
        IList<string> Toppings { get; }
        DoughType Dough { get; set; }
        string Seasonings { get; set; }
        string SauceType { get; set; }
        void Bake();
        void Cut();
        void Box();
    }
}
