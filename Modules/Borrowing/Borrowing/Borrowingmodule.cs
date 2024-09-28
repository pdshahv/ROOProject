
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Borrowing
{
    public static class Borrowingmodule
    {
        public static IServiceCollection AddBorrowingModule(this IServiceCollection services,
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
