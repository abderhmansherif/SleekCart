namespace SleekCart.Application.Exceptions;

public sealed class NotFoundCartException: ApplicationException
{
    public NotFoundCartException(): base("Cart Not Found.")
    {
        
    }
}
