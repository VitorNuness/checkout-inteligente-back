namespace Presentation.Controllers;

using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public readonly ITokenService _tokenService;

    public AuthController(
        IUserService userService,
        ITokenService tokenService
        )
    {
        this._userService = userService;
        this._tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthOutputDTO?>> Register(UserInputDTO userInputDTO)
    {
        User? user = await this._userService.Create(userInputDTO);
        string token = this._tokenService.CreateToken(user);

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
        User? user = await this._userService.GetByCredentials(userCredentialsDTO);
        string token = this._tokenService.CreateToken(user);

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
        User user = await this._userService.Get(Int32.Parse(userId));

        return this.Ok(
            new UserOutputDTO(user)
        );
    }
}
