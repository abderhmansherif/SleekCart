namespace SleekCart.Application.Exceptions;

public sealed class NotFoundPaymentException: ApplicationException
{
    public NotFoundPaymentException(string? orderId = null): 
            base($"Not Found Payment {(string.IsNullOrEmpty(orderId)? "" : $"With That Order Id: {orderId}")}")
    {
    }   
}
