using e_commerse.Domain.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_commerse.Domain.Exceptions.ProductImage
{
    public class EmptyProductImageIdException: ProductImageException
    {
        public EmptyProductImageIdException() : base("Product image ID cannot be empty.")
        {
            
        }
    }
}
