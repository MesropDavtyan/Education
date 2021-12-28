using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBasket
{
    public class Good : ICartItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
    }
}
