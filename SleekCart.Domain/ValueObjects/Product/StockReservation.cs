using e_commerse.Domain.ValueObjects.Cart;

namespace e_commerse.Domain.ValueObjects.Product
{
    public record StockReservation
    {
        public CartId CartId { get; private set; }
        public int Quantity { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public bool IsExpired => DateTime.UtcNow > ExpiryDate;
        private StockReservation() { }  

        public StockReservation(CartId cartId, int quantity, TimeSpan duration)
        {
            CartId = cartId;
            Quantity = quantity;
            ExpiryDate = DateTime.UtcNow.Add(duration);
        }
    }
}
