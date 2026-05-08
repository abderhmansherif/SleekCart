using e_commerse.Domain.Abstractions.Exceptions;

namespace SleekCart.Domain.Exceptions.Cart;

public sealed class AlreadyUpdatedCategoryException: CategoryException
{
    public AlreadyUpdatedCategoryException():base("Already Updated Category Name.")
    {
    }
}
