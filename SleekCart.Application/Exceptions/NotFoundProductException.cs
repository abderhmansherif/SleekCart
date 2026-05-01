namespace SleekCart.Application.Exceptions;

public sealed class NotFoundProductException: ApplicationException
{
    public NotFoundProductException(): base("Product Not Found")
    {
        
    }
}
