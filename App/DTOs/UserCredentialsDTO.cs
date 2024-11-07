namespace App.DTOs;

using System.Diagnostics.CodeAnalysis;

[method: SetsRequiredMembers]
public class UserCredentialsDTO(
    string email,
    string password
    )
{
    public required string Email { get; set; } = email;

    public required string Password { get; set; } = password;
}
