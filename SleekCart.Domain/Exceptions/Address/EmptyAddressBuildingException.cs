using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Address
{
    public class EmptyAddressBuildingException : AddressException
    {
        public EmptyAddressBuildingException() : base("Address building cannot be empty.")
        {
        }
    }
}
