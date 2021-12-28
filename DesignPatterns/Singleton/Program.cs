using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton firstInstance = Singleton.Instance();
            Singleton secondInstance = Singleton.Instance();

            if (firstInstance == secondInstance)
            {
                Console.WriteLine("Objects are the same instance");
            }
        }
    }
}
