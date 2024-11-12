namespace Core.DTOs;

using Core.Models;

public class UserOutputDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }

    public UserOutputDTO(
        User user
    )
    {
        this.Id = user.Id;
        this.Name = user.Name;
        this.Email = user.Email;
        this.Role = user.Role.ToString();
    }
}
