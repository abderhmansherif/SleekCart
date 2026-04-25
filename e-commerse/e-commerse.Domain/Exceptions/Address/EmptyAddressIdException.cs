using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Address
{
    public class EmptyAddressIdException: AddressException
    {
        public EmptyAddressIdException() : base("Address ID cannot be empty.")
        {

        }
    }
}
