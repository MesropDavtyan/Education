using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopBasket
{
    class Program
    {
        List<CartItem> cartItems = cart.getItems();
        List<Discount> discounts = extractDiscountsFromItems(cartItems);
        applyDiscountsOnCartItems(discounts, cartItems);
        List<Products> discountProducts = extractProductsFromItems(cartItems);
        int totalAmount = calculateAmount(discountProducts);
        return totalAmount;

        static void Main(string[] args)
        {
        }
    }
}
