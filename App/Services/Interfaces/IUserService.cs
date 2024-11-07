namespace App.Services.Interfaces;

using System.Collections.Generic;
using App.Models;

public interface IUserService
{
    public List<User> GetAll();
    public User? GetById(int id);
    public void Create(User data);
    public void Update(int id, User data);
    public void Delete(int id);
}
