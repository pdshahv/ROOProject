


namespace BooksCatalog.Books.Features.CreateBook
{
    public record CreateBookRequest(BookDto Book);

    public record CreateBookResponse(Guid Id);
    public class CreateBookEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/books", async (CreateBookRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateBookCommand>();
                var result = await sender.Send(command);

                var response = result.Adapt<CreateBookResponse>();

                return Results.Created($"/Books/{response.Id}", response);
            })
            .WithName("CreateBook")
            .Produces<CreateBookResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Book")
            .WithDescription("Create Book");

        }
    }
}
