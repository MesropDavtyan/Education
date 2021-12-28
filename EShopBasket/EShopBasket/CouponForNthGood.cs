using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBasket
{
    public class CouponForNthGood : ICartItem
    {
        public int GiveDiscount(List<Good> goods, string category, int goodNumber)
        {
            var discount = 0;

            for (int i = 0; i < goods.Count(); i++)
            {
                if (goods[i].Category == category && i == goodNumber - 1)
                {
                    discount = goods[i].Price * 10 / 100;
                }
            }

            return discount;
        }
    }
}
