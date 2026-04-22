using e_commerse.Domain.Exceptions.OrderStatusHistory;

namespace e_commerse.Domain.ValueObjects.OrderStatusHistory
{
    public record OrderHistoryNote
    {
        public string Value { get; }

        public OrderHistoryNote(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                throw new EmptyOrderHistoryNote();
            }

            Value = value;
        }

        public static implicit operator string(OrderHistoryNote orderHistoryNote) => orderHistoryNote.Value;
        public static implicit operator OrderHistoryNote(string value) => new OrderHistoryNote(value);
    }
}
