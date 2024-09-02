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
            return _productService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Product?> Show(int id)
        {
            return _productService.GetById(id);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Product> Store(Product data)
        {
            _productService.Create(data);

            return data;
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Update(int id, Product data)
        {
            _productService.Update(id, data);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.Delete(id);

            return NoContent();
        }
    }
}
