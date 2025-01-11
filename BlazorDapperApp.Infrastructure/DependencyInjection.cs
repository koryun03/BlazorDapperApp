using Domain.RepositoryInterfaces;
using Infrastructure.Database;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISqlConnectionFactory>(provider =>
               new SqlConnectionFactory(configuration.GetConnectionString("DefaultConnection")));

            services.RepositoriesInit();
        }

        private static void RepositoriesInit(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
