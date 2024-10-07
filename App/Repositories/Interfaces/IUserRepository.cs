namespace App.Repositories.Interfaces;

using System.Collections.Generic;
using App.Models;

public interface IUserRepository
{
    public List<User> GetAll();
    public User? Get(int id);
    public void Store(User data);
    public void Update(int id, User data);
    public void Delete(int id);
}
