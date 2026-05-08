namespace SleekCart.Application.Services;

public interface ICategoryReadService
{
    Task<bool> IsExistAsync(string CategoryName, CancellationToken cancellationToken);
}
