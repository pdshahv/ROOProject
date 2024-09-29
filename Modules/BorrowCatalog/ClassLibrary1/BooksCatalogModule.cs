using BooksCatalog.Data;
using BooksCatalog.Data.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data.Intercepter;


namespace BookManagement
{
    public static class BooksCatalogModule
    {
        public static IServiceCollection AddBookCatalogModule(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Add services to the container.
            // Data
            var connectionString = configuration.GetConnectionString("Database");
            services.AddDbContext<BooksCatalogDBContext>(options =>
            {
                options.AddInterceptors(new LogEntityInterceptors());

                options.UseSqlServer(connectionString);
            }
                          );

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
