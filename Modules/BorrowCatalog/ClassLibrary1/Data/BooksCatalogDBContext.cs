using Microsoft.EntityFrameworkCore;
using BooksCatalog.Books.Models;
using System.Reflection;

namespace BooksCatalog.Data
{
    public class BooksCatalogDBContext :DbContext
    {
        public BooksCatalogDBContext(DbContextOptions<BooksCatalogDBContext> options) :base(options) { }

        public DbSet<Book> Books => Set<Book>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("BooksCatalog");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
