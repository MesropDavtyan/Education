using AbstractFactory.Component;
using AbstractFactory.ConcreteComponent;
using AbstractFactory.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.ConcreteFactory
{
    public class AmericaFactory : ContinentFactory
    {
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }

        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
    }
}
