using SleekCart.Domain.Enums.Order;
using SleekCart.Domain.ValueObjects.Order;
using SleekCart.Domain.ValueObjects.OrderStatusHistory;

namespace SleekCart.Domain.Entities
{
    public class OrderStatusHistory
    {
        public OrderHistoryId Id { get; private set; }
        public OrderId OrderId { get; private set; }
        public OrderStatus Status { get; private set; }
        public OrderHistoryNote Note { get; private set; }
        public DateTime ChangedAt { get; private set; }

        public OrderStatusHistory(OrderId orderId, OrderStatus status, OrderHistoryNote note)
        {
            this.Id = new OrderHistoryId(Guid.NewGuid());
            this.OrderId = orderId;
            this.Status = status;
            this.Note = note;
            this.ChangedAt = DateTime.UtcNow;
        }
    }
}