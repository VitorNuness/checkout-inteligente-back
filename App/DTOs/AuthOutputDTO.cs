namespace App.DTOs;

using System.Diagnostics.CodeAnalysis;

[method: SetsRequiredMembers]
public class AuthOutputDTO(
    UserOutputDTO userOutputDTO,
    string token
    )
{
    public required UserOutputDTO User { get; set; } = userOutputDTO;

    public required string Token { get; set; } = token;
}
