
using Microsoft.AspNetCore.Builder;
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

        public static IApplicationBuilder UseBorrowingModule(this IApplicationBuilder app)
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
