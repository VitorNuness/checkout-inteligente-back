using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Services.Interfaces;

namespace App.Services
{
    public class UserService : IUserService
    {
        public List<User> GetAll()
        {
            return new List<User>();
        }

        public User? GetById(int id, string? sort = null)
        {
            return null;
        }

        public void Create(User data)
        {
            return;
        }

        public void Update(int id, User data)
        {
            return;
        }

        public void Delete(int id)
        {
            return;
        }
    }
}
