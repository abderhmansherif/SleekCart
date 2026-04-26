using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class InsufficientStockException: ProductException
    {
        public InsufficientStockException(): base("Insufficient stock available for the requested quantity.")
        {
            
        }
    }
}
