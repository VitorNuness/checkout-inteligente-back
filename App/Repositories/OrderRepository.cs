using App.Models;
using App.Repositories.Database;
using App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CheckoutDbContext _dbContext;

        public OrderRepository(
            CheckoutDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public List<Order> GetAll()
        {
            return _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                    .ThenInclude(o => o.Product)
                .ToList();
        }

        public Order? Get(int id)
        {
            return _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                    .ThenInclude(o => o.Product)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public Order? GetCurrentUserOrder(int userId)
        {
            return _dbContext.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                    .ThenInclude(o => o.Product)
                .Where(o => o.UserId == userId && o.IsComplete == false)
                .FirstOrDefault();
        }

        public async void Store(Order data)
        {
            _dbContext.Orders.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public void Update(int id, Order data)
        {
            Order? order = this.Get(id);
            if (order != null)
            {
                order.Id = id;
                _dbContext.Entry(order).CurrentValues.SetValues(data);
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Order? order = this.Get(id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
            }

            _dbContext.SaveChanges();
        }
    }
}
