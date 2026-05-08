namespace SleekCart.Application.Exceptions;

public sealed class AlreadyExistCategoryException: ApplicationException
{
    public AlreadyExistCategoryException(string name): base($"Already Exist Category With Name '{name}'.")
    {
        
    }
}
