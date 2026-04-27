namespace SleekCart.Application.Exceptions;

public sealed class NotFoundUserException: ApplicationException
{
    public NotFoundUserException()
        : base("User Not Found")
    {}
}
