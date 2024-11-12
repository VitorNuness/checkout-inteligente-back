namespace Core.DTOs;

public class UserCredentialsDTO
{
    public string Email { get; set; }
    public string Password { get; set; }

    public UserCredentialsDTO(
        string email,
        string password
    )
    {
        this.Email = email;
        this.Password = password;
    }
}
