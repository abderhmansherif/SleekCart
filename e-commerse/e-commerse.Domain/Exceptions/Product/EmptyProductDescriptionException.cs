using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class EmptyProductDescriptionException: ProductException
    {
        public EmptyProductDescriptionException(): base("Product description cannot be empty.")
        {
            
        }
    }
}
