using Borrowing.LibBorrow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Borrowing.Data.Configuration
{
    public class BorrowEntriesItemConfiguration : IEntityTypeConfiguration<BorrowEntriesItem>
    {


        public void Configure(EntityTypeBuilder<BorrowEntriesItem> builder)
        {
            builder.Property(oi => oi.BookId).IsRequired();
            builder.Property(oi => oi.BorrowEntryId).IsRequired();
            builder.Property(oi => oi.Title).IsRequired();

        }
    }
}
