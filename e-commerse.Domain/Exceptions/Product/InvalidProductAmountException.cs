using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class InvalidProductAmountException: ProductException
    {
        public InvalidProductAmountException(): base("The amount cannot be negative.")
        {
            
        }
    }
}
