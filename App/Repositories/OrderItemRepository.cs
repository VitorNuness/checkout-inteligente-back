using App.Models;
using App.Repositories.Database;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class OrderItemRepository
    {
        private readonly CheckoutDbContext _dbContext;

        public OrderItemRepository(
            CheckoutDbContext dbContext
        )
        {
            _dbContext = dbContext;
        }

        public List<OrderItem> GetAll()
        {
            return _dbContext.OrderItems
                .Include(o => o.Product)
                .ToList();
        }

        public OrderItem? Get(int id)
        {
            return _dbContext.OrderItems
                .Include(o => o.Product)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }
        public OrderItem? GetByProductAndOrder(int productId, int orderId)
        {
            return _dbContext.OrderItems
                .Include(o => o.Product)
                .Where(o => o.ProductId == productId && o.OrderId == orderId)
                .FirstOrDefault();
        }

        public void Store(OrderItem data)
        {
            _dbContext.OrderItems.Add(data);
            _dbContext.SaveChanges();
        }

        public void Update(int id, OrderItem data)
        {
            OrderItem? item = this.Get(id);
            if (item != null)
            {
                item.Id = id;
                _dbContext.Entry(item).CurrentValues.SetValues(data);
            }

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            OrderItem? item = this.Get(id);
            if (item != null)
            {
                _dbContext.OrderItems.Remove(item);
            }

            _dbContext.SaveChanges();
        }
    }
}
