
using Borrowing.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Shared.Data.Intercepter;
using Shared.Data;
namespace Borrowing
{
    public static class Borrowingmodule
    {
        public static IServiceCollection AddBorrowingModule(this IServiceCollection services,
       IConfiguration configuration)
        {
            // Add services to the container.


            // Data infra layer
            var connectionString = configuration.GetConnectionString("Database");

            services.AddScoped<ISaveChangesInterceptor, LogEntityInterceptors>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<BorrowDBContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
            });


            return services;
        }

        public static IApplicationBuilder UseBorrowingModule(this IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline.


            //Data infra layer
            app.UseMigration<BorrowDBContext>();

            return app;
        }
    }
}
