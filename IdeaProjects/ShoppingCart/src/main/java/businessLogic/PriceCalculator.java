package businessLogic;

import cartItems.*;
import interfaces.ICartItem;

import java.util.List;

/*
   Imagine you have an e-shop with discounts. Discounts are provided as coupons.
   Coupons can be of 3 types:
    1) deduct percent of price from the current item
    2) deduct percent of price from the next item
    3) deduct an exact sum in dollars from N next items
   Imagine you have a shopping cart with some items in it and some coupons (of the types above).
   Write a program that will calculate final price of the order (after applying all coupons).
   Order of coupons application matters. Each type of coupon may appear from zero to infinite times.
*/

public class PriceCalculator {
    public static double calculateTotalPriceV1(List<ICartItem> items) {
        double totalPrice = 0;

        for (int i = 0; i < items.size(); i++) {
            switch (items.get(i).getClass().getName()) {
                case "cartItems.Product":
                    totalPrice += ((Product) items.get(i)).getPrice();
                    break;
                case "cartItems.CouponV1":
                    double deduction = ((CouponV1) items.get(i)).getDeduction();

                    switch ( ((CouponV1) items.get(i)).getCouponType()) {
                        case DeductPercentCurrent:
                            for (int j = i - 1; j >= 0; j--) {
                                if (items.get(j) instanceof Product) {
                                    totalPrice -= ((Product) items.get(j)).getPrice() * deduction / 100;
                                    break;
                                }
                            }
                            break;
                        case DeductPercentNext:
                            for (int j = i + 1; j < items.size(); j++) {
                                if (items.get(j) instanceof Product) {
                                    totalPrice -= ((Product) items.get(j)).getPrice() * deduction / 100;
                                    break;
                                }
                            }
                            break;
                        case DeductSum:
                            int productCount = ((CouponV1) items.get(i)).getProductCount();

                            for (int j = i + 1; j < items.size(); j++) {
                                if (items.get(j) instanceof Product && productCount > 0) {
                                    totalPrice -= deduction;
                                    --productCount;
                                }
                            }
                            break;
                    }
                    break;
                default:
                    throw new IllegalStateException("Unexpected value: " + items.get(i).getClass());
            }
        }

        return totalPrice;
    }

    public static double calculateTotalPriceV2(List<ICartItem> items) {
        double totalPrice = 0;

        for (int i = 0; i < items.size(); i++) {
            if (items.get(i) instanceof CouponV2) {
                ((CouponV2) items.get(i)).deductPrice(i, items);
            }
        }

        for (ICartItem item : items) {
            if (item instanceof Product) {
                totalPrice += ((Product) item).getPrice();
            }
        }

        return totalPrice;
    }
}
