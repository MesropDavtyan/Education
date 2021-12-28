using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBasket
{
    public class CouponByCategory: ICartItem
    {
        public int GiveDiscount(List<Good> goods, string category)
        {
            var discount = 0;

            foreach (var good in goods)
            {
                if (good.Category == category)
                {
                    discount = good.Price * 5 / 100;
                }
            }

            return discount;
        }
    }
}
