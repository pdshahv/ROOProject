using Borrowing.LibBorrow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Borrowing.Data.Configuration
{
    public class BorrowListItemConfiguration : IEntityTypeConfiguration<BorrowListItem>
    {


        public void Configure(EntityTypeBuilder<BorrowListItem> builder)
        {
            builder.Property(oi => oi.BookId).IsRequired();
            builder.Property(oi => oi.BorrowEntryId).IsRequired();
            builder.Property(oi => oi.Title).IsRequired();

        }
    }
}
