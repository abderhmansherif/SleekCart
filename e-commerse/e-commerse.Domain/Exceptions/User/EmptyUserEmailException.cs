using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.User
{
    public class EmptyUserEmailException : UserException
    {
        public EmptyUserEmailException(): base("User email cannot be empty.")
        {
            
        }
    }
}
