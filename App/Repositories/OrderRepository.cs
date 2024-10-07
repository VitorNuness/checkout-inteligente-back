namespace App.Repositories;

using App.Exceptions;
using App.Models;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;

public class OrderRepository(
    CheckoutDbContext dbContext
    )
{
    private readonly CheckoutDbContext _dbContext = dbContext;

    public async Task<Order> FindOrFail(int id) => await this._dbContext.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .ThenInclude(p => p.Category)
            .Where(o => o.Id == id)
            .FirstOrDefaultAsync() ??
            throw new NotExistException("Order not exists.");

    public async Task<List<Order>> FindWhereUser(User user) => await this._dbContext.Orders
            .Where(o => o.User == user)
            .ToListAsync();

    public async Task<Order> FindOrFailCurrentUserOrder(User user) => await this._dbContext.Orders
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .ThenInclude(p => p.Category)
            .Where(o => o.User.Id == user.Id && o.Status == Enums.EOrderStatus.CURRENT)
            .FirstOrDefaultAsync() ??
            throw new NotExistException("Order not exists.");

    public async Task<Order> FindOrCreateCurrentUserOrder(User user)
    {
        try
        {
            return await this.FindOrFailCurrentUserOrder(user);
        }
        catch (NotExistException)
        {
            Order order = new(user);

            return await this.Store(order);
        }
    }

    public async Task<Order> Store(Order order)
    {
        this._dbContext.Orders.Add(order);
        await this._dbContext.SaveChangesAsync();

        return order;
    }

    public async Task<Order> Update(Order oldOrder, Order newOrder)
    {
        this._dbContext.Entry(oldOrder).CurrentValues.SetValues(newOrder);

        await this._dbContext.SaveChangesAsync();

        return newOrder;
    }
}
