namespace Core.Repositories;

using Core.DTOs;
using Core.Models;

public interface IUserRepository
{
    public Task<IEnumerable<User?>> GetAll();

    public Task<User> FindOrFail(int id);

    public Task<User> FindByCredentialsOrFail(UserCredentialsDTO userCredentialsDTO);

    public Task<User> Store(UserInputDTO userInputDTO);

    public Task Update(int id, User data);

    public Task Delete(int id);
}
