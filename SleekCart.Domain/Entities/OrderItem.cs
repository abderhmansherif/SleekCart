using e_commerse.Domain.ValueObjects.Order;
using e_commerse.Domain.ValueObjects.Product;

namespace e_commerse.Domain.Entities
{
    public class OrderItem
    {
        public OrderId OrderId { get; private set; }
        public ProductId ProductId { get; private set; }
        public int Quantity { get; private set; }
        public Money Price { get; private set; }
        public decimal Total => Price.Amount * Quantity;

        public OrderItem(Guid orderId, ProductId productId, int quantity, Money price)
        {
            this.OrderId = orderId;
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
