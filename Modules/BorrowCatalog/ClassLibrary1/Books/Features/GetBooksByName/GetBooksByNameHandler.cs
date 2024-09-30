using BooksCatalog.Books.Dtos;
using BooksCatalog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Books.Features.GetBooksByName
{

    public record GetBooksByNameQuery(string bookname)
        :IQuery<GetBooksByNameResult>;

    public record GetBooksByNameResult(IEnumerable<BookDto> Books);

    internal class GetBooksByNameHandler(BooksCatalogDBContext dbContext)
        : IQueryHandler<GetBooksByNameQuery, GetBooksByNameResult>
    {
        public async Task<GetBooksByNameResult> Handle(GetBooksByNameQuery query, CancellationToken cancellationToken)
        {
           //get book by name

            var books = await dbContext.Books
                    .AsNoTracking()
                    .Where(s=>s.Name.Contains(query.bookname))
                    .OrderBy(s=>s.Name)
                    .ToListAsync(cancellationToken);

            var bookDtos = books.Adapt<List<BookDto>>();

            return new GetBooksByNameResult(bookDtos);
        }
    }
}
