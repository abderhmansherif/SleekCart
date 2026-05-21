namespace SleekCart.Application.Exceptions;

public sealed class InvalidOrderStatusException: ApplicationException
{
    public InvalidOrderStatusException():base("Invalid Order Status.")
    {
        
    }
}
