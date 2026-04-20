using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class EmptyProductAmountCurrencyException: ProductException
    {
        public EmptyProductAmountCurrencyException(): base("the amount currency can not be empty")
        {
            
        }
    }
}
