using SleekCart.Domain.ValueObjects.Cart;
using SleekCart.Domain.ValueObjects.Product;

namespace SleekCart.Domain.Entities
{
    public class CartItem
    {
        public ProductId ProductId { get; private set; }
        public CartId CartId { get; private set; }
        public int Quantity { get; private set; } = 0;
        public Money Price { get; private set; }
        public decimal Total => Price.Amount * Quantity;

        public CartItem(ProductId productId, CartId cartId, int quantity, Money price)
        {
            ProductId = productId;
            CartId = cartId;
            Price = price;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int amount)
        {
            if(amount <= 0)
            {
                throw new InvalidQuantityException();
            }

            Quantity += amount;
        }
    }
}
