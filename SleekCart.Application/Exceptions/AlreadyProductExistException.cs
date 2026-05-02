namespace SleekCart.Application.Exceptions;

public sealed class AlreadyProductExistException: ApplicationException
{
    public AlreadyProductExistException(): base("Product Already Exists.")
    {
        
    }
}
