package cartItems;

import interfaces.ICartItem;

import java.util.List;

public abstract class CouponV2 implements ICartItem {
    private final double deduction;

    protected CouponV2(double deduction) {
        this.deduction = deduction;
    }

    public abstract void deductPrice(int couponIndex, List<ICartItem> items);

    public double getDeduction() {
        return deduction;
    }
}
