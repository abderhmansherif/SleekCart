using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.User
{
    public class AddressNotFoundException: UserException
    {
        public AddressNotFoundException() : base("Address not found for this user.")
        {
        }
    }
}
