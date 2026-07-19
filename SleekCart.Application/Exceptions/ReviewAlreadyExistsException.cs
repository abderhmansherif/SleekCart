namespace SleekCart.Application.Exceptions;

public sealed class ReviewAlreadyExistsException: ApplicationException
{
    public ReviewAlreadyExistsException(): base("You have already submitted a review for this product.")
    {
        
    }
}
