using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;

namespace App.Services.Interfaces
{
    public interface IOrderService
    {
        public List<Order> GetAll();
        public Order? GetById(int id);
        public void Create(Order data);
        public void Update(int id, Order data);
        public void Delete(int id);
    }
}
