using App.DTOs;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(
            CategoryService categoryService
        )
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category?>>> Index()
        {
            return Ok(await _categoryService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Show(int id)
        {
            Category category = await _categoryService.GetById(id);

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Store(CategoryInputDTO categoryInputDTO)
        {
            Category category = await _categoryService.Create(categoryInputDTO);

            return CreatedAtAction(nameof(Store), category);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CategoryInputDTO categoryInputDTO)
        {
            await _categoryService.Update(id, categoryInputDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);

            return NoContent();
        }
    }
}
