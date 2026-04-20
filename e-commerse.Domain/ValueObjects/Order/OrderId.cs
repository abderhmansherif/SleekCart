using e_commerse.Domain.Exceptions.Order;

namespace e_commerse.Domain.ValueObjects.Order
{
    public record OrderId
    {
        public Guid Value { get; }

        public OrderId(Guid value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new EmptyOrderIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(OrderId OrderId) => OrderId.Value;

        public static implicit operator OrderId(Guid value) => new OrderId(value);
    }
}
