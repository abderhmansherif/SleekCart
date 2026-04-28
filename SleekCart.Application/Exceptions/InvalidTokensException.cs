namespace SleekCart.Application.Exceptions;

public sealed class InvalidTokensException: ApplicationException
{
    public InvalidTokensException(): base("Inavlid Tokens.")
    {}
}
