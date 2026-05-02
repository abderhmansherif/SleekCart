namespace SleekCart.Application.Exceptions;

public sealed class StorageUploadException: ApplicationException
{
    public StorageUploadException(): base("Failed to upload files")
    {   
    }
}
