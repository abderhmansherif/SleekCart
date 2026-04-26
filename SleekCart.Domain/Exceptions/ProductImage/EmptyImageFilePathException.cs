using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.ProductImage
{
    public class EmptyImageFilePathException : ProductImageException
    {
        public EmptyImageFilePathException() : base("Image file path cannot be empty.")
        {
        }
    }
}
