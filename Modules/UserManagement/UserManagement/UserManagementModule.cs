
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace UserManagement
{
    public static class UserManagementModule
    {
             public static IServiceCollection AddUserManagementModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Add services to the container.
            //services
            //  .AddApplicationServices()
            //  .AddInfrastructureServices(configuration)
            //  .AddApiServices(configuration);
            return services;
        }
    }
}
