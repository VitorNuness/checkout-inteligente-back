namespace App.Controllers;

using App.DTOs;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController(
    UserService userService,
    TokenService tokenService
        ) : ControllerBase
{
    private readonly UserService _userService = userService;

    public readonly TokenService _tokenService = tokenService;

    [HttpPost("register")]
    public async Task<ActionResult<AuthOutputDTO?>> Register(UserInputDTO userInputDTO)
    {
        var user = await this._userService.Create(userInputDTO);
        var token = this._tokenService.CreateToken(user);

        return this.CreatedAtAction(nameof(Register),
            new AuthOutputDTO(
                new UserOutputDTO(user),
                token
            )
        );
    }

    [HttpPost("login")]
    public async Task<ActionResult<User?>> Login(UserCredentialsDTO userCredentialsDTO)
    {
        var user = await this._userService.GetByCredentials(userCredentialsDTO);
        var token = this._tokenService.CreateToken(user);

        return this.Ok(
            new AuthOutputDTO(
                new UserOutputDTO(user),
                token
            )
        );
    }
}
