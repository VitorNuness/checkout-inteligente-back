namespace App.Services;
using System.Threading.Tasks;

public class FileService
{
    public async Task SaveFile(IFormFile file, string path)
    {
        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
    }

    public async Task RemoveFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
