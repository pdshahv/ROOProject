using Borrowing.LibBorrow.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Borrowing.Data
{
    public class BorrowDBContext :DbContext
    {
        public BorrowDBContext(DbContextOptions<BorrowDBContext> options) : base(options) { }

        public DbSet<BorrowEntry> BorrowEntries => Set<BorrowEntry>();
        public DbSet<BorrowEntriesItem>  borrowEntriesItems => Set<BorrowEntriesItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("borrowCatalog");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating( builder);
            
        }

    }
}
