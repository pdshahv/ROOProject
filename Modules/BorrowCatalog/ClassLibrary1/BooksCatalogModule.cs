using BooksCatalog.Data;
using BooksCatalog.Data.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data.Intercepter;
using System.Reflection;


namespace BookManagement
{
    public static class BooksCatalogModule
    {
        public static IServiceCollection AddBookCatalogModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Add services to the container.

            // Application Use Case services
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            // Data
            var connectionString = configuration.GetConnectionString("Database");

            services.AddScoped<ISaveChangesInterceptor,LogEntityInterceptors>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<BooksCatalogDBContext>((sp,options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IDataSeeder, BooksCatalogDataSeeder>();
            return services;
        }

        public static IApplicationBuilder UseBookCatalogModule(this IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline.
            app.UseMigration<BooksCatalogDBContext>();

            return app;
        }

    }
}
