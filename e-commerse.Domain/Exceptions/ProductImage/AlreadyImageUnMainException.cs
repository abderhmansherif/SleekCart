using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.ProductImage
{
    public class AlreadyImageUnMainException: ProductImageException
    {
        public AlreadyImageUnMainException() : base("This image is already not the main image.")
        {
        } 
    }
}
