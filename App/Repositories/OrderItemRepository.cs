using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Database;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class OrderItemRepository
    {
        private readonly CheckoutDbContext DbContext;

        public OrderItemRepository()
        {
            this.DbContext = new CheckoutDbContext();
        }

        public List<OrderItem> GetAll()
        {
            return this.DbContext.OrderItems
                .Include(o => o.Product)
                .ToList();
        }

        public OrderItem? Get(int id)
        {
            return this.DbContext.OrderItems
                .Include(o => o.Product)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }
        public OrderItem? GetByProductAndOrder(int productId, int orderId)
        {
            return this.DbContext.OrderItems
                .Include(o => o.Product)
                .Where(o => o.ProductId == productId && o.OrderId == orderId)
                .FirstOrDefault();
        }

        public void Store(OrderItem data)
        {
            this.DbContext.OrderItems.Add(data);
            this.DbContext.SaveChanges();
        }

        public void Update(int id, OrderItem data)
        {
            OrderItem? item = this.Get(id);
            if (item != null)
            {
                item.Id = id;
                this.DbContext.Entry(item).CurrentValues.SetValues(data);
            }

            this.DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            OrderItem? item = this.Get(id);
            if (item != null)
            {
                this.DbContext.OrderItems.Remove(item);
            }

            this.DbContext.SaveChanges();
        }
    }
}
