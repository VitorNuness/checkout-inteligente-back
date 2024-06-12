using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Repositories;
using App.Services.Interfaces;


namespace App.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository Repository;
        private readonly OrderService OrderService;

        public UserService()
        {
            this.Repository = new UserRepository();
            this.OrderService = new OrderService();
        }

        public List<User> GetAll()
        {
            return this.Repository.GetAll();
        }

        public User? GetById(int id)
        {
            return this.Repository.Get(id);
        }

        public void Create(User data)
        {
            this.Repository.Store(data);
            Order? newOrder = new Order(data);
            this.OrderService.Create(newOrder);
        }

        public void Update(int id, User data)
        {
            this.Repository.Update(id, data);
        }

        public void Delete(int id)
        {
            this.Repository.Delete(id);
        }
    }
}
