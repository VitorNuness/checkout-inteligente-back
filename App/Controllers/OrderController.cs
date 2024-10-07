namespace App.Controllers;

using App.DTOs;
using App.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders")]
public class OrderController(
    OrderService orderService
    ) : ControllerBase
{
    private readonly OrderService _orderService = orderService;

    [HttpGet("user/{userId}/orders/current")]
    public async Task<ActionResult<OrderDTO?>> GetCurrentUserOrder(int userId)
    {
        var order = await this._orderService.GetCurrentUserOrder(userId);

        return this.Ok(new OrderDTO(order));
    }

    [HttpGet("user/{userId}/orders")]
    public async Task<ActionResult<List<OrderDTO?>>> GetUserOrders(int userId)
    {
        var orders = await this._orderService.GetUserOrders(userId);

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
}
