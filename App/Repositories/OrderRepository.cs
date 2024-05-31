using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Database;
using App.Models;
using App.Repositories.Interfaces;

namespace App.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CheckoutDbContext DbContext;

        public OrderRepository()
        {
            this.DbContext = new CheckoutDbContext();
        }

        public List<Order> GetAll()
        {
            return this.DbContext.Orders.ToList();
        }

        public Order? Get(int id)
        {
            return this.DbContext.Orders.Find(id);
        }

        public void Store(Order data)
        {
            this.DbContext.Orders.Add(data);
            this.DbContext.SaveChanges();
        }

        public void Update(int id, Order data)
        {
            Order? order = this.Get(id);
            if (order != null)
            {
                order.Id = id;
                this.DbContext.Entry(order).CurrentValues.SetValues(data);
            }

            this.DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Order? order = this.Get(id);
            if (order != null)
            {
                this.DbContext.Orders.Remove(order);
            }

            this.DbContext.SaveChanges();
        }
    }
}
