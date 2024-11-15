using System;

namespace Core.DTOs;

public class AuthOutputDTO
{
    public UserOutputDTO User { get; set; }
    public string Token { get; set; }

    public AuthOutputDTO(
        UserOutputDTO user,
        string token
    )
    {
        this.User = user;
        this.Token = token;
    }
}
