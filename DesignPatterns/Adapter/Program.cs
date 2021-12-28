using Adapter.Adapter;
using Adapter.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IVendor vendor = new VendorAdapter();
            var products = vendor.GetProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
