using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class ProductImageLimitExceededException: ProductException
    {
        public ProductImageLimitExceededException(): base("Product Image Limit Exceeded.")
        {
            
        }
    }
}
