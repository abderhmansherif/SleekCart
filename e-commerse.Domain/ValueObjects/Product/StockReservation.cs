using e_commerse.Domain.ValueObjects.Cart;

namespace e_commerse.Domain.ValueObjects.Product
{
    public record StockReservation
    {
        public CartId CartId { get; private set; }
        public int Quantity { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        public StockReservation(CartId cartId, int quantity, DateTime expiryDate)
        {
            CartId = cartId;
            Quantity = quantity;
            ExpiryDate = expiryDate;
        }
    }
}
