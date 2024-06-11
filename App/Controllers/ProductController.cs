using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ProductService Service;

        public ProductController()
        {
            this.Service = new ProductService();
        }

        [HttpGet]
        public ActionResult<List<Product>?> Index(int? category = null, string? sort = null)
        {
            return this.Service.GetAll(category, sort);
        }

        [HttpGet("{id}")]
        public ActionResult<Product?> Show(int id)
        {
            return this.Service.GetById(id);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Product> Store(Product data)
        {
            this.Service.Create(data);

            return data;
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult Update(int id, Product data)
        {
            this.Service.Update(id, data);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            this.Service.Delete(id);

            return NoContent();
        }
    }
}
