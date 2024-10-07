namespace App.Controllers;

using App.DTOs;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
[Authorize]
public class UserController(
    UserService userService
    ) : ControllerBase
{
    private readonly UserService _userService = userService;

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
    public ActionResult Update(int id, User data)
    {
        this._userService.Update(id, data);

        return this.NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        this._userService.Delete(id);

        return this.NoContent();
    }
}
