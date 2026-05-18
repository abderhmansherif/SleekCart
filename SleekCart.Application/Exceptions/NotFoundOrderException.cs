namespace SleekCart.Application.Exceptions;

public sealed class NotFoundOrderException: ApplicationException
{
    public NotFoundOrderException(): base("Order Not Found.")
    {
        
    }
}