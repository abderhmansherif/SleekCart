namespace e_commerse.Domain.Abstractions.Exceptions
{
    public abstract class ProductImageException : DomainException
    {
        public ProductImageException(string msg) : base(msg)
        { }
    }
}
