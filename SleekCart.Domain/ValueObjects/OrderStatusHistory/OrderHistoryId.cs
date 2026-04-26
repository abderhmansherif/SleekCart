using e_commerse.Domain.Exceptions.OrderStatusHistory;

namespace SleekCart.Domain.ValueObjects.OrderStatusHistory
{
    public record OrderHistoryId
    {
        public Guid Value { get; }

        public OrderHistoryId(Guid value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyOrderHistoryId();
            }

            Value = value;
        }

        public static implicit operator Guid(OrderHistoryId orderHistoryId) => orderHistoryId.Value;

        public static implicit operator OrderHistoryId(Guid value) => new OrderHistoryId(value);
    }
}
