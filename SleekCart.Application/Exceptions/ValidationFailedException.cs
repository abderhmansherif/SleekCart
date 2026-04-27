using FluentValidation.Results;

namespace SleekCart.Application.Exceptions;

public sealed class ValidationFailedException: ApplicationException
{
    public List<string> Errors {get;}
    public ValidationFailedException(IEnumerable<ValidationFailure> failures)
        :base("Validation failed.") 
    {
        Errors = failures.Select(f => f.ErrorMessage).ToList();
    }
}
