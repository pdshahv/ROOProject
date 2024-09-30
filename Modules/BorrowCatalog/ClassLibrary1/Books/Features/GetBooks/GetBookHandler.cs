

using BooksCatalog.Books.Dtos;
using BooksCatalog.Data;


namespace BooksCatalog.Books.Features.GetBooks
{

    public record GetBooksQuery()
        :IQuery<GetBooksResult>;

    public record GetBooksResult(IEnumerable<BookDto> books);
    internal class GetBookHandler(BooksCatalogDBContext dbContext) :IQueryHandler<GetBooksQuery,GetBooksResult>
    {
        public async Task<GetBooksResult> Handle(GetBooksQuery request,CancellationToken cancellationToken)
        {
            //get books using dbcontext

            var books = await dbContext.Books
                        .AsNoTracking()
                        .OrderBy(p => p.Name)
                        .ToListAsync(cancellationToken);

            //mapping book entity to bookdto
            var bookDtos = books.Adapt<List<BookDto>>();

            return new GetBooksResult(bookDtos);
        }

    }
}
