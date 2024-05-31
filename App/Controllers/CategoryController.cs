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
        private readonly CategoryService Service;

        public CategoryController()
        {
            this.Service = new CategoryService();
        }

        [HttpGet]
        public ActionResult<List<Category>> Index()
        {
            return this.Service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> Show(int id, string? sort)
        {
            Category? category = this.Service.GetById(id, sort);

            if (category != null)
            {
                return category;
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Store(Category category)
        {
            this.Service.Create(category);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Category category)
        {
            this.Service.Update(id, category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            this.Service.Delete(id);

            return NoContent();
        }
    }
}
