using e_commerse.Domain.Abstractions.Exceptions;
using e_commerse.Domain.Entities;

namespace e_commerse.Domain.Exceptions.ProductImage
{
    public class EmptyImageFileNameException: ProductImageException
    {
        public EmptyImageFileNameException() : base("Image file name cannot be empty.")
        {
            
        }
    }
}
