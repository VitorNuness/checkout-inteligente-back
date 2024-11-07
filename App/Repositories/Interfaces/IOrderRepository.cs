namespace App.Repositories.Interfaces;

using System.Collections.Generic;
using App.Models;

public interface IOrderRepository
{
    public List<Order> GetAll();
    public Order? Get(int id);
    public void Store(Order data);
    public void Update(int id, Order data);
    public void Delete(int id);
}
