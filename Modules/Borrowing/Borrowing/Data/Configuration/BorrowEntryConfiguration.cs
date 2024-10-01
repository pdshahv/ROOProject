using Borrowing.LibBorrow.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrowing.Data.Configuration
{
    internal class BorrowEntryConfiguration : IEntityTypeConfiguration<BorrowEntry>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BorrowEntry> builder)
        {
           builder.HasKey(e=>e.Id);
            builder.Property(oi => oi.UserId).IsRequired();
            builder.HasMany(e => e.Entries)
                .WithOne()
                .HasForeignKey(si => si.BorrowEntryId);

        }
    }
}
