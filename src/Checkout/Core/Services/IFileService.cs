namespace Core.Services;

using Microsoft.AspNetCore.Http;

public interface IFileService
{
    public Task SaveFile(IFormFile file, string path);

    public Task RemoveFile(string path);
}
