namespace SleekCart.Application.Services;

public interface IStorageService
{
    Task<string> UploadAsync(string FileName, string ContentType, Stream stream);
    Task DeleteAsync(string FileUrl);

}
