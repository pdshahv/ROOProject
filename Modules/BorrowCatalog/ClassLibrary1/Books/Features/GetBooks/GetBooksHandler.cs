

using BooksCatalog.Books.Dtos;
using BooksCatalog.Data;
using Shared.Pagination;


namespace BooksCatalog.Books.Features.GetBooks
{

    public record GetBooksQuery(PaginationRequest PaginationRequest)
        :IQuery<GetBooksResult>;

    public record GetBooksResult(PaginatedResult<BookDto> books);
    internal class GetBooksHandler(BooksCatalogDBContext dbContext)
        :IQueryHandler<GetBooksQuery,GetBooksResult>
    {
        public async Task<GetBooksResult> Handle(GetBooksQuery query,CancellationToken cancellationToken)
        {
            //get books using dbcontext

            var pageIndex = query.PaginationRequest.PageIndex;
            var pageSize = query.PaginationRequest.PageSize;
            var totalCount = await dbContext.Books.LongCountAsync(cancellationToken);

            var books = await dbContext.Books
                        .AsNoTracking()
                        .OrderBy(p => p.Name)
                        .Skip(pageSize * pageIndex)
                        .Take(pageSize)
                        .ToListAsync(cancellationToken);

            //mapping book entity to bookdto
            var bookDtos = books.Adapt<List<BookDto>>();

            return new GetBooksResult(
                new PaginatedResult<BookDto>(
                    pageIndex,
                    pageSize,
                    totalCount,
                    bookDtos)
                    );
        }

    }
}
