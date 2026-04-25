using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Address
{
    public class EmptyAddressCityException : AddressException
    {
        public EmptyAddressCityException() : base("Address city cannot be empty.")
        {
        }
    }
}
