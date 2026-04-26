using e_commerse.Domain.Abstractions.Exceptions;
using e_commerse.Domain.ValueObjects.Product;

namespace e_commerse.Domain.Exceptions.Product
{
    public class InvalidProductPriceException: ProductException
    {
        public InvalidProductPriceException(): base("Product price must be greater than zero.")
        {
            
        }
    }
}
