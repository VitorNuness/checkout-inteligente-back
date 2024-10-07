namespace App.DTOs;

using System.Diagnostics.CodeAnalysis;
using App.Models;

[method: SetsRequiredMembers]
public class UserOutputDTO(
    User user
    )
{
    public required int Id { get; set; } = user.Id;

    public required string Name { get; set; } = user.Name;

    public required string Email { get; set; } = user.Email;

    public required string Role { get; set; } = user.Role.ToString();
}
