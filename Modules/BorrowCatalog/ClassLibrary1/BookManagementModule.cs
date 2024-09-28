using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BookManagement
{
    public static class BookManagementModule
    {
        public static IServiceCollection AddBookManagementModule(this IServiceCollection services,
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
