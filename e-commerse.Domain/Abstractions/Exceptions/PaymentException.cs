namespace e_commerse.Domain.Abstractions.Exceptions
{
    public class PaymentException : DomainException
    {
        public PaymentException(string msg)
            : base(msg)
        {  
        }
    }
}
