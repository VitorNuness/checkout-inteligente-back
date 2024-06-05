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

        [HttpPost]
        public ActionResult<Order> Store(Order order)
        {
            this.Service.Create(order);

            return order;
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
