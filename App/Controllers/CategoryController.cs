using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult<List<Category>> Index()
        {
            return _categoryService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Show(int id, string? sort)
        {
            Category? category = _categoryService.GetById(id, sort);

            if (category != null)
            {
                return category;
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Category> Store(Category category)
        {
            _categoryService.Create(category);

            return category;
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Category category)
        {
            _categoryService.Update(id, category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _categoryService.Delete(id);

            return NoContent();
        }
    }
}
