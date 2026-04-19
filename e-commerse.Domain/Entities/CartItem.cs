using e_commerse.Domain.ValueObjects.Cart;
using e_commerse.Domain.ValueObjects.Product;

namespace e_commerse.Domain.Entities
{
    public class CartItem
    {
        public ProductId ProductId { get; set; }
        public CartId CartId { get; set; }
        public int Quantity { get; set; }

        public CartItem(ProductId productId, CartId cartId, int quantity)
        {
            ProductId = productId;
            CartId = cartId;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int amount)
            => Quantity += amount;
    }
}
