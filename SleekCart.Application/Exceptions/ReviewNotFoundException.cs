namespace SleekCart.Application.Exceptions;

public sealed class ReviewNotFoundException: ApplicationException
{
    public ReviewNotFoundException() : base("The review was not found.")
    {}
}
