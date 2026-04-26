using e_commerse.Domain.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerse.Domain.Exceptions.ProductImage
{
    public class AlreadyImageMainException: ProductImageException
    {
        public AlreadyImageMainException(): base("This image is already the main image.")
        {
            
        }
    }
}
