namespace e_commerse.Domain.Abstractions.Exceptions
{
    public abstract class CartException : DomainException
    {
        public CartException(string msg): base(msg)
        {
            
        }
    }
}
