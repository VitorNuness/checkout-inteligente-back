namespace Presentation.Controllers;

using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/auth")]
public class AuthController(
    IUserService userService,
    ITokenService tokenService
        ) : ControllerBase
{
    private readonly IUserService _userService = userService;

    public readonly ITokenService _tokenService = tokenService;

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

    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult<UserOutputDTO>> GetUser()
    {
        var userId = this.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")!.Value;
        var user = await this._userService.Get(int.Parse(userId));

        return this.Ok(
            new UserOutputDTO(user)
        );
    }
}
