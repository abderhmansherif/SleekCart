namespace SleekCart.Application.Exceptions;

public sealed class NotFoundPaymentException: ApplicationException
{
 public NotFoundPaymentException(string OrderId): 
            base($"Not Found Payment With That Order Id: {OrderId}")
 {}   
}
