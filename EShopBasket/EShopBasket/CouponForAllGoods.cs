using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBasket
{
    public class CouponForAllGoods : ICartItem
    {
        public int GiveDiscount(List<Good> goods)
        {
            var discount = 0;

            foreach (var good in goods)
            {
                discount = good.Price * 10 / 100;
            }

            return discount;
        }
    }
}
