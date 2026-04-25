using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Order
{
    public class InvalidOrderStatusTransitionException: OrderException
    {
        public InvalidOrderStatusTransitionException()
            : base("Invalid order status transition.") {}
    }
}
