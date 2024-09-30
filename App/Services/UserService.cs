using App.DTOs;
using App.Models;
using App.Repositories;


namespace App.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(
            UserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User?>> GetAll() => await _userRepository.GetAll();

        public async Task<User> Get(int id) => await _userRepository.FindOrFail(id);

        public async Task<User> GetByCredentials(UserCredentialsDTO userCredentialsDTO) => await _userRepository.FindByCredentialsOrFail(userCredentialsDTO);

        public async Task<User> Create(UserInputDTO userInputDTO)
        {
            return await _userRepository.Store(userInputDTO);
        }

        public void Update(int id, User data)
        {
            _userRepository.Update(id, data);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
