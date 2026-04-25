using e_commerse.Domain.Abstractions.Exceptions;

namespace e_commerse.Domain.Exceptions.Category
{
    public class EmptyCategoryNameException : CategoryException
    {
        public EmptyCategoryNameException() : base("Category name cannot be empty.")
        {
        }
    }
}
