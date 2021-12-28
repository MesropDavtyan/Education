using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetTest
{
    class Class1
    {
        public Class1(string[] a)
        {
            foreach (string str in a)
            {
                Console.WriteLine(str);
            }
        }
    }
}
