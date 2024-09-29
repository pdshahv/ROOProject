using Microsoft.EntityFrameworkCore;


namespace BooksCatalog.Data.Seed
{
    public class BooksCatalogDataSeeder(BooksCatalogDBContext dbContext):IDataSeeder
    {
        public async Task SeedAllAsync()
        {
            if(!await dbContext.Books.AnyAsync())
            {
                await dbContext.Books.AddRangeAsync(InitialData.Books);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
