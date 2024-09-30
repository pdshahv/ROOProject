using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Books.Features.GetBooksByName
{
    //public record GetBooksByNameRequest(string bookname)
    public record GetBooksByNameResponse(IEnumerable<BookDto> Books);



    public class GetBooksByNameEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/books/name/{bookname}", async (string bookname, ISender sender) =>
            {

                var result = await sender.Send(new GetBooksByNameQuery(bookname));

                var response = result.Adapt<GetBooksByNameResponse>();
                return Results.Ok(response);

            })
             .WithName("GetBookByName")
             .Produces<GetBooksByNameResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Get Book By Name")
             .WithDescription("Get Book By Name");
        }
    }
}
