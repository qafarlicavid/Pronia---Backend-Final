using Pronia_Site___Backend.Contracts.File;

namespace Pronia_Site___Backend.Services.Abstracts
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile formFile, UploadDirectory uploadDirectory);
        string GetFileUrl(string? fileName, UploadDirectory uploadDirectory);
        Task DeleteAsync(string? fileName, UploadDirectory uploadDirectory);
    }
}
