namespace Core.Repositories;

using Core.Models;

public interface IOrderRepository
{
    public Task<List<Order>> FindBetweenDates(DateTime startDate, DateTime endDate);

    public Task<Order> FindOrFail(int id);

    public Task<List<Order?>> FindWhereUser(User user);

    public Task<Order> FindOrFailCurrentUserOrder(User user);

    public Task<Order> FindOrCreateCurrentUserOrder(User user);

    public Task<Order> Store(Order order);

    public Task<Order> Update(Order oldOrder, Order newOrder);
}
