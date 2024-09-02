using App.DTOs;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(
            ProductService productService
        )
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product?>>> Index()
        {
            return Ok(await _productService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> Show(int id)
        {
            return Ok(await _productService.GetById(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Product>> Store(
            [FromForm] ProductInputDTO productInputDTO,
            IFormFile? image = null
        )
        {
            Product product = await _productService.Create(productInputDTO, image);

            return CreatedAtAction(nameof(Store), product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Product>> Update(
            int id,
            [FromForm] ProductInputDTO productInputDTO,
            IFormFile? image = null
        )
        {
            Product product = await _productService.Update(id, productInputDTO, image);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        // [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.Delete(id);

            return NoContent();
        }
    }
}
