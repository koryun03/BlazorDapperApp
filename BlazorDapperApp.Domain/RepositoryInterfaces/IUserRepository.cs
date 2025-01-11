using Domain.Dto;

namespace Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<bool> Insert(UserInsertDto UserDto);
        Task<bool> Update(UserDto UserDto);
        // Task<bool> Delete(UserDto UserDto);
        Task<bool> Delete(int id);
        Task<UserDto> GetById(int id);
        Task<List<UserDto>> GetAll();

    }
}
