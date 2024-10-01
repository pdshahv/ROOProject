using Borrowing.LibBorrow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrowing.Data.Configuration
{
    internal class BorrowListConfiguration : IEntityTypeConfiguration<BorrowList>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BorrowList> builder)
        {
           builder.HasKey(e=>e.Id);
            builder.Property(oi => oi.UserId).IsRequired();
            builder.HasMany(e => e.Items)
                .WithOne()
                .HasForeignKey(si => si.BorrowEntryId);

        }
    }
}
