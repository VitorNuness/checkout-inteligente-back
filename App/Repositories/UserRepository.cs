using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.Repositories.Interfaces;
using App.Models;
using App.Database;

namespace App.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CheckoutDbContext DbContext;

        public UserRepository()
        {
            this.DbContext = new CheckoutDbContext();
        }

        public List<User> GetAll()
        {
            return this.DbContext.Users.ToList();
        }

        public User Get(int id)
        {
            return this.DbContext.Users.Where(u => u.Id == id).First();
        }

        public void Store(User data)
        {
            this.DbContext.Users.Add(data);
            this.DbContext.SaveChanges();
        }

        public void Update(int id, User data)
        {
            User user = this.Get(id);
            this.DbContext.Users.Update(user);
            this.DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = this.Get(id);
            this.DbContext.Users.Remove(user);
            this.DbContext.SaveChanges();
        }
    }
}
