namespace e_commerse.Domain.Abstractions.Exceptions
{
    public abstract class CouponException : DomainException
    {
        public CouponException(string msg) : base(msg)
        {

        }
    }
}
