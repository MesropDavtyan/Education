using AbstractFactory.Client;
using AbstractFactory.ConcreteFactory;
using AbstractFactory.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ContinentFactory factory = new AmericaFactory();
            AnimalWorld client = new AnimalWorld(factory);
            client.RunFoodChain();
        }
    }
}
