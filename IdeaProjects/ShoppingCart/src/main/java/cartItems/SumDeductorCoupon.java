package cartItems;

import interfaces.ICartItem;

import java.util.List;

public class SumDeductorCoupon extends CouponV2 {
    private int productCount;

    public SumDeductorCoupon(double deduction, int productCount) {
        super(deduction);
        this.productCount = productCount;
    }

    @Override
    public void deductPrice(int couponIndex, List<ICartItem> items) {
        for (int i = couponIndex + 1; i < items.size(); i++) {
            if (items.get(i) instanceof Product && productCount > 0) {
                double price = ((Product) items.get(i)).getPrice();
                price -= this.getDeduction();
                ((Product) items.get(i)).setPrice(price);

                --productCount;
            }
        }
    }
}
