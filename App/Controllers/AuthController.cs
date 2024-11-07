using System.Security.Claims;
using App.DTOs;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public readonly TokenService _tokenService;

        public AuthController(
            UserService userService,
            TokenService tokenService
            )
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthOutputDTO?>> Register(UserInputDTO userInputDTO)
        {
            User? user = await _userService.Create(userInputDTO);
            string token = _tokenService.CreateToken(user);

            return CreatedAtAction(nameof(Register),
                new AuthOutputDTO(
                    new UserOutputDTO(user),
                    token
                )
            );
        }

        [HttpPost("login")]
        public async Task<ActionResult<User?>> Login(UserCredentialsDTO userCredentialsDTO)
        {
            User? user = await _userService.GetByCredentials(userCredentialsDTO);
            string token = _tokenService.CreateToken(user);

            return Ok(
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
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "id")!.Value;
            User user = await _userService.Get(Int32.Parse(userId));

            return Ok(
                new UserOutputDTO(user)
            );
        }
    }
}
