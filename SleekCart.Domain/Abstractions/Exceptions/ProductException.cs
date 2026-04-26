namespace e_commerse.Domain.Abstractions.Exceptions
{
    public abstract class ProductException : DomainException
    {
        public ProductException(string msg) :base(msg)
        {
            
        }
    }
}
