using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.User
{
    public class AddressAlreadyExistsException: UserException
    {
        public AddressAlreadyExistsException() : base("Address with the same building already exists for this user.")
        {

        }
    }
}
