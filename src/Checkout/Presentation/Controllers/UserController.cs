namespace Presentation.Controllers;

using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService) => this._userService = userService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User?>>> Index() => this.Ok(await this._userService.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<User?>> Show(int id) => this.Ok(await this._userService.Get(id));

    [HttpPost()]
    public async Task<ActionResult<User>> Store(UserInputDTO userInputDTO)
    {
        var user = await this._userService.Create(userInputDTO);

        return this.CreatedAtAction(nameof(Store), user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, User data)
    {
        await this._userService.Update(id, data);

        return this.NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await this._userService.Delete(id);

        return this.NoContent();
    }
}
