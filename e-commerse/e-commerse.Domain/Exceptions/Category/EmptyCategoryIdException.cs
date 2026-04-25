using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Category
{
    public class EmptyCategoryIdException : CategoryException
    {
        public EmptyCategoryIdException(): base("Category Id cannot be empty.")
        {
            
        }
    }
}
