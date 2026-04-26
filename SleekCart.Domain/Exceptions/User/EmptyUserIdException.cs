using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.User
{
    public class EmptyUserIdException: UserException
    {
        public EmptyUserIdException() : base("User Id cannot be empty.")
        {
            
        }
    }
}
