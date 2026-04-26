using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class ProductImageNotFoundException: ProductException
    {
        public ProductImageNotFoundException(): base("Product image not found.")
        {
            
        }
    }
}
