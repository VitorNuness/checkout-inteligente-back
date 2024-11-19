namespace Presentation.Controllers;

using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/products")]
public class ProductController(
    IProductService productService
    ) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product?>>> Index() => this.Ok(await this._productService.GetAll());

    [HttpGet("best-sellers")]
    public async Task<ActionResult<IEnumerable<Product?>>> BestSellers() => this.Ok(await this._productService.GetBestSellers());

    [HttpGet("{id}")]
    public async Task<ActionResult<Product?>> Show(int id) => this.Ok(await this._productService.GetById(id));

    [HttpPost]
    // [Authorize(Roles = "admin")]
    public async Task<ActionResult<Product>> Store(
        [FromForm] ProductInputDTO productInputDTO,
        IFormFile? image = null
    )
    {
        var product = await this._productService.Create(productInputDTO, image);

        return this.CreatedAtAction(nameof(Store), product);
    }

    [HttpPut("{id}")]
    // [Authorize(Roles = "admin")]
    public async Task<ActionResult<Product>> Update(
        int id,
        [FromForm] ProductInputDTO productInputDTO,
        IFormFile? image = null
    )
    {
        var product = await this._productService.Update(id, productInputDTO, image);

        return this.Ok(product);
    }

    [HttpDelete("{id}")]
    // [Authorize(Roles = "admin")]
    public async Task<ActionResult> Delete(int id)
    {
        await this._productService.Delete(id);

        return this.NoContent();
    }
}
