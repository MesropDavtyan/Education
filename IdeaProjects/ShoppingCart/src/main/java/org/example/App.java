package org.example;

import businessLogic.PriceCalculator;
import cartItems.CouponV1;
import cartItems.CurrentDeductorCoupon;
import cartItems.Product;
import cartItems.SumDeductorCoupon;
import enums.CouponType;
import interfaces.ICartItem;

import java.util.ArrayList;
import java.util.List;

public class App {
    public static void main(String[] args) {
        List<ICartItem> items = new ArrayList<>();

        /*items.add(new Product(100));
        items.add(new CouponV1(CouponType.DeductPercentCurrent,20));
        items.add(new CouponV1(CouponType.DeductPercentCurrent,20));*/

        items.add(new Product(100));
        items.add(new CurrentDeductorCoupon(20));
        items.add(new CurrentDeductorCoupon(20));
/*        items.add(new SumDeductorCoupon(20, 2));
        items.add(new Product(100));
        items.add(new Product(100));
        items.add(new Product(100));
        items.add(new CurrentDeductorCoupon(20));*/

        System.out.println(PriceCalculator.calculateTotalPriceV2(items));
    }
}
