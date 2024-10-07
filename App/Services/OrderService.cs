namespace App.Services;

using App.Models;
using App.Repositories;

public class OrderService(
    UserService userService,
    ProductService productService,
    OrderRepository orderRepository
    )
{
    private readonly UserService _userService = userService;
    private readonly ProductService _productService = productService;
    private readonly OrderRepository _orderRepository = orderRepository;

    public async Task<List<Order>> GetUserOrders(int userId)
    {
        var user = await this._userService.Get(userId);

        return await this._orderRepository.FindWhereUser(user);
    }

    public async Task<Order> GetCurrentUserOrder(int userId)
    {
        var user = await this._userService.Get(userId);

        return await this._orderRepository.FindOrCreateCurrentUserOrder(user);
    }

    public async Task AddProduct(int id, int productId)
    {
        var order = await this._orderRepository.FindOrFail(id);
        var product = await this._productService.GetById(productId);

        order.AddProduct(product);

        await this._orderRepository.Update(order, order);
    }

    public async Task RemoveProduct(int id, int productId)
    {
        var order = await this._orderRepository.FindOrFail(id);
        var product = await this._productService.GetById(productId);

        order.RemoveProduct(product);

        await this._orderRepository.Update(order, order);
    }

    public async Task CompleteOrder(int id)
    {
        var order = await this._orderRepository.FindOrFail(id);

        order.CompleteOrder();

        order.Items?.ForEach(i => i?.Product.AddSale());

        await this._orderRepository.Update(order, order);
    }
}
