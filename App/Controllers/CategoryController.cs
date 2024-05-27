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
        public ActionResult<Category> Show(int id)
        {
            return this.Service.GetById(id);
        }

        [HttpPost]
        public ActionResult Store(User user)
        {
            this.Service.Create(user);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, User data)
        {
            this.Service.Update(id, data);

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
