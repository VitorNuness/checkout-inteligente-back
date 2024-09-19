using App.Exceptions;
using App.Models;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class OrderRepository
    {
        private readonly CheckoutDbContext _dbContext;

        public OrderRepository(
            CheckoutDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public async Task<Order> FindOrFail(int id)
        {
            return await _dbContext.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.Id == id)
                .FirstOrDefaultAsync() ??
                throw new NotExistException("Order not exists.");
        }

        public async Task<Order> FindOrFailCurrentUserOrder(User user)
        {
            return await _dbContext.Orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .Where(o => o.User.Id == user.Id && o.Status == Enums.EOrderStatus.CURRENT)
                .FirstOrDefaultAsync() ??
                throw new NotExistException("Order not exists.");
        }

        public async Task<Order> FindOrCreateCurrentUserOrder(User user)
        {
            try
            {
                return await FindOrFailCurrentUserOrder(user);
            }
            catch (NotExistException)
            {
                Order order = new(user);

                return await Store(order);
            }
        }

        public async Task<Order> Store(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();

            return order;
        }

        public async Task<Order> Update(Order oldOrder, Order newOrder)
        {
            _dbContext.Entry(oldOrder).CurrentValues.SetValues(newOrder);

            await _dbContext.SaveChangesAsync();

            return newOrder;
        }
    }
}
