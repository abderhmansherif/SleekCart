using e_commerse.Domain.Abstractions.Exceptions;

namespace SleekCart.Domain.Exceptions.Category;

public sealed class TooLongCategoryNameException: CategoryException
{
    public TooLongCategoryNameException():base("Too Long Category Name, Should not upper than 20 letter.")
    {
        
    }
}
