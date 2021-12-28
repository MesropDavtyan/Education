using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Component
{
    public abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }
}
