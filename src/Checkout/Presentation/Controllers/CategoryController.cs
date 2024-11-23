namespace Presentation.Controllers;

using Core.Services;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/categories")]
public class CategoryController(
    ICategoryService categoryService
    ) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    public async Task<ActionResult<List<Category?>>> Index() => this.Ok(await this._categoryService.GetAll());

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> Show(int id)
    {
        var category = await this._categoryService.GetById(id);

        return this.Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> Store(
       [FromForm] CategoryInputDTO categoryInputDTO,
       IFormFile? image = null
        )
    {
        var category = await this._categoryService.Create(categoryInputDTO, image);

        return this.CreatedAtAction(nameof(Store), category);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(
        int id,
        [FromForm] CategoryInputDTO categoryInputDTO,
        IFormFile? image = null
    )
    {
        await this._categoryService.Update(id, categoryInputDTO, image);

        return this.NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await this._categoryService.Delete(id);

        return this.NoContent();
    }
}
