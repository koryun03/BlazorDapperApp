using Application.ServiceInterfaces;
using Domain.Dto;
using Domain.RepositoryInterfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<List<UserDto>> GetAll()
        {
            return await _userRepository.GetAll();
        }

        public async Task<UserDto> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<bool> Insert(UserInsertDto UserDto)
        {
            return await _userRepository.Insert(UserDto);
        }

        public async Task<bool> Update(UserDto UserDto)
        {
            return await _userRepository.Update(UserDto);
        }
    }
}
