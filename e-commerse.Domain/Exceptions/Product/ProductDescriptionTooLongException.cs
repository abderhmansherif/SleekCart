using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class ProductDescriptionTooLongException : ProductException
    {
        public ProductDescriptionTooLongException() : base("Product description cannot be longer than 600 characters.")
        {

        }
    }
}
