namespace SleekCart.Application.Exceptions;

public sealed class NotFoundCategoryException: ApplicationException
{
    public NotFoundCategoryException(): base("Category Not Found.")
    {}
}
