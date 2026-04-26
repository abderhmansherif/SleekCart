using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Order
{
    public class InvalidShippingAddressArgumentException: OrderException
    {
        public InvalidShippingAddressArgumentException(string msg): base(msg)
        {

        }
    }
}
