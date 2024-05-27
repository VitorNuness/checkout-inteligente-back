using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public List<Order> GetAll();
        public Order? Get(int id);
        public void Create(Order data);
        public void Update(int id, Order data);
        public void Delete(int id);
    }
}
