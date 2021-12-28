using Decorator.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Decorator
{
    abstract class CarDecorator: ICar
    {
        private ICar _car;

        public CarDecorator(ICar car)
        {
            _car = car;
        }
        public string Make { get { return _car.Make; } }

        public double GetPrice()
        {
            return _car.GetPrice();
        }
        public abstract double GetDiscountedPrice();
    }
}
