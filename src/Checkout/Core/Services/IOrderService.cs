namespace Core.Services;

using Core.Models;

public interface IOrderService
{
    public Task<List<Order?>> GetUserOrders(int userId);

    public Task<Order> GetCurrentUserOrder(int userId);

    public Task AddProduct(int id, int productId);

    public Task RemoveProduct(int id, int productId);

    public Task CompleteOrder(int id);

    public Task CreateCSVForOrdersBetweenDates(DateTime startDate, DateTime endDate);
}
