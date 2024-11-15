namespace Core.DTOs;

public class UserInputDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public UserInputDTO(
        string name,
        string email,
        string password
    )
    {
        this.Name = name;
        this.Email = email;
        this.Password = password;
    }
}
