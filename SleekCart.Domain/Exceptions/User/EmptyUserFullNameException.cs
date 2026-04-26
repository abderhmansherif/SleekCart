using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.User
{
    public class EmptyUserFullNameException : UserException
    {
        public EmptyUserFullNameException() : base("User full name cannot be empty.")
        {
        }
    }
}
