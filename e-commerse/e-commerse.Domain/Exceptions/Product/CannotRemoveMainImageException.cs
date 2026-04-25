using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class CannotRemoveMainImageException: ProductException
    {
        public CannotRemoveMainImageException(): base("Cannot remove main image.")
        {
        }
    }
}
