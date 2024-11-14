namespace App.Controllers;

using Core.Services;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(
        IOrderService orderService
    )
    {
        this._orderService = orderService;
    }

    [HttpGet("user/{userId}/orders/current")]
    public async Task<ActionResult<OrderDTO?>> GetCurrentUserOrder(int userId)
    {
        Order order = await this._orderService.GetCurrentUserOrder(userId);

        return this.Ok(new OrderDTO(order));
    }

    [HttpGet("user/{userId}/orders")]
    public async Task<ActionResult<List<OrderDTO?>>> GetUserOrders(int userId)
    {
        List<Order> orders = await this._orderService.GetUserOrders(userId);

        return this.Ok(orders.Select(o => new OrderDTO(o)));
    }

    [HttpPost("{id}/add-product")]
    public async Task<ActionResult> AddProductInOrder(int id, int productId)
    {
        await this._orderService.AddProduct(id, productId);

        return this.NoContent();
    }

    [HttpPost("{id}/remove-product")]
    public async Task<ActionResult> RemoveProductInOrder(int id, int productId)
    {
        await this._orderService.RemoveProduct(id, productId);

        return this.NoContent();
    }

    [HttpPost("{id}/complete")]
    public async Task<ActionResult> CompleteOrder(int id)
    {
        await this._orderService.CompleteOrder(id);

        return this.NoContent();
    }

    [HttpPost("export/csv")]
    public async Task<ActionResult> ExportToCSV(DateTime startDate, DateTime endDate)
    {
        await this._orderService.CreateCSVForOrdersBetweenDates(startDate, endDate.Date.AddHours(23).AddMinutes(59));

        return this.Ok();
    }
}
