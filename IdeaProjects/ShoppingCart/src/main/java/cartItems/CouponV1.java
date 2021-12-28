package cartItems;

import enums.CouponType;
import enums.ItemType;
import interfaces.ICartItem;

public class CouponV1 implements ICartItem {
    private final ItemType itemType;
    private final CouponType couponType;
    private final double deduction;
    private int productCount;

    public CouponV1(CouponType couponType, double deduction) {
        this.itemType = ItemType.coupon;
        this.couponType = couponType;
        this.deduction = deduction;
    }

    public CouponV1(CouponType couponType, double deduction, int productCount) {
        this.itemType = ItemType.coupon;
        this.couponType = couponType;
        this.deduction = deduction;
        this.productCount = productCount;
    }

    /*@Override
    public ItemType getItemType() {
        return this.itemType;
    }*/

    public CouponType getCouponType() {
        return couponType;
    }

    public double getDeduction() {
        return deduction;
    }

    public int getProductCount() {
        return productCount;
    }
}
