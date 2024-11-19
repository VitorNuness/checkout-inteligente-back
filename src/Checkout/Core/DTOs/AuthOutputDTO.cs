namespace Core.DTOs;

public class AuthOutputDTO(
    UserOutputDTO user,
    string token
    )
{
    public UserOutputDTO User { get; set; } = user;
    public string Token { get; set; } = token;
}
