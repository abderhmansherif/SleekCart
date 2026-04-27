namespace SleekCart.Application.Exceptions;

public class AlreadyUserRegisteredException: ApplicationException
{
    public AlreadyUserRegisteredException(string email) 
        :base($"User with email '{email}' already exists.")
    {}
}
