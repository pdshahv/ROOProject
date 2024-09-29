using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BooksCatalog.Books.Models;


namespace BooksCatalog.Data.Configuration
{
    public class BooksConfiguration : IEntityTypeConfiguration<Book>
    {
      

        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p=>p.Name).HasMaxLength(50).IsRequired();
        }
    }
}
