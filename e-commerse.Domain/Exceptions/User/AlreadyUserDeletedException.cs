using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.User
{
    public class AlreadyUserDeletedException: UserException
    {
        public AlreadyUserDeletedException(): base("User has already been deleted.")
        {
        }
    }
}
