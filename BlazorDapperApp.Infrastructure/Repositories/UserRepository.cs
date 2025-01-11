using Dapper;
using Domain.Dto;
using Domain.Entity;
using Domain.RepositoryInterfaces;
using Infrastructure.Database;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlConnectionFactory _connectionFactory;

        public UserRepository(ISqlConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> Delete(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                var query = "Delete  FROM Users WHERE Id = @Id";
                connection.Execute(query, new { Id = id });

                return true;
            }
        }

        public async Task<List<UserDto>> GetAll()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Users";
                var users = await connection.QueryAsync<User>(query);

                var userDtos = users.Select(user => new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    City = user.City,
                }).ToList();

                return userDtos;
            }
        }

        public async Task<UserDto> GetById(int id)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM Users WHERE Id = @Id";
                var user = await connection.QueryFirstOrDefaultAsync<User>(query, new { Id = id });

                var userDto = new UserDto
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    City = user.City,
                };

                return userDto;
            }
        }

        public async Task<bool> Insert(UserInsertDto UserDto)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();

                var query = "INSERT INTO Users (FirstName, LastName, Address, City) " +
                            "VALUES (@FirstName, @LastName, @Address, @City)";

                await connection.ExecuteAsync(query, new
                {
                    FirstName = UserDto.FirstName,
                    LastName = UserDto.LastName,
                    Address = UserDto.Address,
                    City = UserDto.City
                });
                return true;
            }
        }

        public async Task<bool> Update(UserDto UserDto)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                await connection.OpenAsync();

                var query = "UPDATE Users set FirstName = @FirstName, LastName=@LastName, Address=@Address,City=@City  where Id = @Id";

                connection.Execute(query, new
                {
                    Id = UserDto.Id,
                    FirstName = UserDto.FirstName,
                    LastName = UserDto.LastName,
                    Address = UserDto.Address,
                    City = UserDto.City
                });

                return true;
            }
        }
    }
}