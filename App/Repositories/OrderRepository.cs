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

        public async Task<Order> WhereUser(User user)
        {
            return await _dbContext.Orders.Where(o => o.User.Id == user.Id).FirstOrDefaultAsync() ??
                throw new NotExistException("Order not exists.");
        }

        public async Task<Order> FindOrCreateCurrentUserOrder(User user)
        {
            try
            {
                return await WhereUser(user);
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
    }
}
