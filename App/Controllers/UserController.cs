using App.DTOs;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{

    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(
            UserService userService
        )
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User?>>> Index()
        {
            return Ok(await _userService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> Show(int id)
        {
            return Ok(await _userService.Get(id));
        }

        [HttpPost()]
        public async Task<ActionResult<User>> Store(UserInputDTO userInputDTO)
        {
            User user = await _userService.Create(userInputDTO);

            return CreatedAtAction(nameof(Store), user);
        }
    }
}
