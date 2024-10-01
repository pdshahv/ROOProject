using Borrowing.LibBorrow.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Borrowing.Data
{
    public class BorrowDBContext :DbContext
    {
        public BorrowDBContext(DbContextOptions<BorrowDBContext> options) : base(options) { }

        public DbSet<BorrowList> BorrowEntries => Set<BorrowList>();
        public DbSet<BorrowListItem>  borrowEntriesItems => Set<BorrowListItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("borrowCatalog");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating( builder);
            
        }

    }
}
