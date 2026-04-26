using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class EmptyProductIdException : ProductException
    {
        public EmptyProductIdException(): base("Product Id cannot be empty.")
        {
            
        }
    }
}
