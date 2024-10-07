namespace App.Services.Interfaces;

using System.Collections.Generic;
using App.Models;

public interface IOrderService
{
    public List<Order> GetAll();
    public Order? GetById(int id);
    public void Create(Order data);
    public void Update(int id, Order data);
    public void Delete(int id);
}
