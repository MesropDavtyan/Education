using Decorator.Component;
using Decorator.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.ConcreteDecorator
{
    class OfferPrice : CarDecorator
    {
        public OfferPrice(ICar car) : base(car)
        {
        }
        public override double GetDiscountedPrice()
        {
            return .8 * base.GetPrice();
        }
    }
}
