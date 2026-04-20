using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class InvalidProductAmountException: ProductException
    {
        public InvalidProductAmountException(): base("the amount can not be less than one currency.")
        {
            
        }
    }
}
