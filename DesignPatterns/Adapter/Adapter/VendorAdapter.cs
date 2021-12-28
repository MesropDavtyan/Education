using Adapter.Adaptee;
using Adapter.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter.Adapter
{
    public class VendorAdapter : VendorAdaptee, IVendor
    {
        public List<string> GetProducts()
        {
            return GetListOfProducts().Take(2).ToList();
        }
    }
}
