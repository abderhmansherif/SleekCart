namespace SleekCart.Application.Exceptions;

public sealed class InvalidCredentialsException: ApplicationException
{
    public InvalidCredentialsException() :base("Invalid email or password.")
    {}
}
