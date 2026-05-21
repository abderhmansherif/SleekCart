using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Order
{
    public class CannotCancelOrderException: OrderException
    {
        public CannotCancelOrderException(): base("This order can't be cancelled at this stage. Please contact support if you need help.")
        {}
    }
}
