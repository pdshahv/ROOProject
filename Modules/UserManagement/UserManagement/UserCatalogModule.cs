
using Microsoft.AspNetCore.Builder;
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

        public static IApplicationBuilder UseUserManagementModule(this IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline.
            //app
            //  .AddApplicationServices()
            //  .AddInfrastructureServices(configuration)
            //  .AddApiServices(configuration);
            return app;
        }
    }
}
