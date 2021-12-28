package cartItems;

import enums.ItemType;
import interfaces.ICartItem;

public class Product implements ICartItem {
    private final ItemType itemType;

    private double price;

    public Product(double price) {
        this.itemType = ItemType.product;
        this.price = price;
    }

    public void setPrice(double price) {
        this.price = price;
    }

    public double getPrice() {
        return price;
    }
}
