namespace Core.Services;

using Core.Models;

public interface ITokenService
{
    public string CreateToken(User user);
}
