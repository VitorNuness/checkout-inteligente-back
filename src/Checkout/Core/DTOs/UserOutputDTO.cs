namespace Core.DTOs;

using Core.Models;

public class UserOutputDTO(
    User user
    )
{
    public int Id { get; set; } = user.Id;
    public string Name { get; set; } = user.Name;
    public string Email { get; set; } = user.Email;
    public string Role { get; set; } = user.Role.ToString();
}
