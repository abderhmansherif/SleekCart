namespace e_commerse.Domain.Abstractions.Exceptions
{
    public abstract class PaymentException : DomainException
    {
        public PaymentException(string msg)
            : base(msg)
        {  
        }
    }
}
