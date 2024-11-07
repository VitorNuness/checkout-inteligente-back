namespace App.DTOs;

using System.Diagnostics.CodeAnalysis;

[method: SetsRequiredMembers]
public class UserInputDTO(
    string name,
    string email,
    string password
    )
{
    public required string Name { get; set; } = name;

    public required string Email { get; set; } = email;

    public required string Password { get; set; } = password;
}
