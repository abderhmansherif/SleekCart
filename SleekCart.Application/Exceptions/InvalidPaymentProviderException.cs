namespace SleekCart.Application.Exceptions;

public class InvalidPaymentProviderException : Exception
{
    public InvalidPaymentProviderException(string provider)
        : base($"Payment provider '{provider}' is invalid.")
    {
    }
}