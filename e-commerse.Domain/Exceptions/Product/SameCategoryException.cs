using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Product
{
    public class SameCategoryException : ProductException
    {
        public SameCategoryException() : base("The new category is the same as the current category.")
        { 
        }
    }
}
