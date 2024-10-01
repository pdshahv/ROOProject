using Borrowing.LibBorrow.Dtos;
using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;


namespace Borrowing.LibBorrow.Features.NewBorrow
{

    public record NewBorrowRequest(BorrowedListDto borrowList);
    public record NewBorrowResponse(Guid Id);
    public class NewBorrowEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/BorrowList", async (NewBorrowRequest request, ISender sender) =>
            {
                var command = request.Adapt<NewBorrowCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<NewBorrowResponse>();

                return Results.Created($"/BorrowList/{response.Id}", response);
            })
            .Produces<NewBorrowResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Borrow List")
            .WithDescription("Create Borrow List");
            
        }
    }
}
