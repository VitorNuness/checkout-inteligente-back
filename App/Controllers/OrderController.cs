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
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(
            OrderService orderService
        )
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<List<Order>> Index()
        {
            return _orderService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Show(int id)
        {
            Order? order = _orderService.GetById(id);

            if (order != null)
            {
                return order;
            }

            return NotFound();
        }

        [Authorize]
        [HttpGet("current")]
        public ActionResult<Order> GetCurrentUserCart(int userId)
        {
            Order? order = _orderService.GetCurrentUserOrder(userId);

            if (order != null)
            {
                return order;
            }

            return NotFound();
        }

        [Authorize]
        [HttpGet("{id}/suggestions")]
        public ActionResult<List<Product>> ProductSuggestion(int id, bool byCampaigns = false)
        {
            List<Product>? suggestions = new List<Product>();

            if (byCampaigns)
            {
                suggestions = _orderService.GetSuggestionsByCampaigns(id);
            }
            else
            {
                // suggestions = _orderService.GetSuggestions(id);
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
            _orderService.Create(order);

            return order;
        }

        [Authorize]
        [HttpPost("{id}/products/add")]
        public ActionResult<Order> AddProduct(int id, int productId)
        {
            _orderService.AddProduct(id, productId);
            return NoContent();
        }

        [Authorize]
        [HttpPost("{id}/products/remove")]
        public ActionResult<Order> RemoveProduct(int id, int productId)
        {
            _orderService.RemoveProduct(id, productId);
            return NoContent();
        }

        [Authorize]
        [HttpPost("{id}/complete")]
        public ActionResult<Order> CompleteOrder(int id)
        {
            _orderService.CompleteOrder(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Order order)
        {
            _orderService.Update(id, order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _orderService.Delete(id);

            return NoContent();
        }
    }
}
