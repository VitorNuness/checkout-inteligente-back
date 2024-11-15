namespace Core.Services;

using Core.DTOs;
using Core.Models;

public interface IUserService
{
    public Task<IEnumerable<User?>> GetAll();

    public Task<User> Get(int id);

    public Task<User> GetByCredentials(UserCredentialsDTO userCredentialsDTO);

    public Task<User> Create(UserInputDTO userInputDTO);

    public Task Update(int id, User data);

    public Task Delete(int id);
}
