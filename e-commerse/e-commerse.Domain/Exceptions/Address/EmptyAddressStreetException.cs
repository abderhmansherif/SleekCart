using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Address
{
    public class EmptyAddressStreetException : AddressException
    {
        public EmptyAddressStreetException() : base("Address street cannot be empty.")
        {
        }
    }
}
