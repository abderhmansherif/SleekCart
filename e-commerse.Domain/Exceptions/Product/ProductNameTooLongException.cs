using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class ProductNameTooLongException: ProductException
    {
        public ProductNameTooLongException(): base("Product name cannot be longer than 150 characters.")
        {
            
        }
    }
}
