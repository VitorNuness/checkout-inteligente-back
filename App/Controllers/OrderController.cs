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
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService Service;

        public OrderController()
        {
            this.Service = new OrderService();
        }

        [HttpGet]
        public ActionResult<List<Order>> Index()
        {
            return this.Service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Show(int id)
        {
            Order? order = this.Service.GetById(id);

            if (order != null)
            {
                return order;
            }

            return NotFound();
        }

        [HttpGet("/current")]
        public ActionResult<Order> GetCurrentUserCart(int userId)
        {
            Order? order = this.Service.GetCurrentUserOrder(userId);

            if (order != null)
            {
                return order;
            }

            return NotFound();
        }

        [HttpGet("{id}/suggestions")]
        public ActionResult<List<Product>> ProductSuggestion(int id, bool byCampaigns = false)
        {
            List<Product>? suggestions = new List<Product>();

            if (byCampaigns)
            {
                suggestions = this.Service.GetSuggestionsByCampaigns(id);
            }
            else
            {
                suggestions = this.Service.GetSuggestions(id);
            }

            if (suggestions != null)
            {
                return suggestions;
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Order> Store(Order order)
        {
            this.Service.Create(order);

            return order;
        }

        [HttpPost("{id}/products/add")]
        public ActionResult<Order> AddProduct(int id, int productId)
        {
            this.Service.AddProduct(id, productId);
            return NoContent();
        }

        [HttpPost("{id}/products/remove")]
        public ActionResult<Order> RemoveProduct(int id, int productId)
        {
            this.Service.RemoveProduct(id, productId);
            return NoContent();
        }

        [HttpPost("{id}/complete")]
        public ActionResult<Order> CompleteOrder(int id)
        {
            this.Service.CompleteOrder(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Order order)
        {
            this.Service.Update(id, order);

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
