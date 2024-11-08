package cartItems;

import interfaces.ICartItem;

import java.util.List;

public class CurrentDeductorCoupon extends CouponV2 {
    public CurrentDeductorCoupon(double deduction) {
        super(deduction);
    }

    @Override
    public void deductPrice(int couponIndex, List<ICartItem> items) {
        for (int i = couponIndex - 1; i >= 0; i--) {
            if (items.get(i) instanceof Product) {
                double price = ((Product) items.get(i)).getPrice();
                price -= price * this.getDeduction() / 100;
                ((Product) items.get(i)).setPrice(price);
                break;
            }
        }
    }
}
