using e_commerse.Domain.ValueObjects.Cart;
using e_commerse.Domain.ValueObjects.Product;

namespace e_commerse.Domain.Entities
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
            => Quantity += amount;
    }
}
