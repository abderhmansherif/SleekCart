using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class EmptyProductNameException: ProductException
    {
        public EmptyProductNameException(): base("Product name cannot be empty.")
        {
            
        }
    }
}
