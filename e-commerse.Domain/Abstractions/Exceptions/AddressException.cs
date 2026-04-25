namespace e_commerse.Domain.Abstractions.Exceptions
{
    public abstract class AddressException : DomainException
    {
        protected AddressException(string message):base(message)
        {
            
        }
    }
}
