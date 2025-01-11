using Application.ServiceInterfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //   services.AddAutoMapper(typeof(AssemblyReference).Assembly);

            services.ServicesInit();
        }

        private static void ServicesInit(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
