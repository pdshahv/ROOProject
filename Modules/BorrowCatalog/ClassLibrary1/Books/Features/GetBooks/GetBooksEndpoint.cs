using BooksCatalog.Books.Features.GetBooksByName;
using Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Books.Features.GetBooks
{
    //public record GetBooksRequest(PagenationRequest Pagenation Request);
    public record GetBooksResponse (PaginatedResult<BookDto> Books);
    public class GetBooksEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/books", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {

                var result = await sender.Send(new GetBooksQuery(request));
                var response = result.Adapt<GetBooksResponse>();

                return Results.Ok(response);
            })
                .WithName("GetBooks")
                .Produces<GetBooksResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get Books")
                .WithDescription("Get Books");
        
        }
    }
}
