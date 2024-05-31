using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Repositories;
using App.Services.Interfaces;

namespace App.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository Repository;

        public OrderService()
        {
            this.Repository = new OrderRepository();
        }

        public List<Order> GetAll()
        {
            return this.Repository.GetAll();
        }

        public Order? GetById(int id)
        {
            return this.Repository.Get(id);
        }

        public void Create(Order data)
        {
            this.Repository.Store(data);
        }

        public void Update(int id, Order data)
        {
            this.Repository.Update(id, data);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }
    }
}
