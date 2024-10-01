 using Borrowing.Data;
 using Borrowing.LibBorrow.Dtos;
 using Borrowing.LibBorrow.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Shared.CQRS;


namespace Borrowing.LibBorrow.Features.NewBorrow
{

    public record NewBorrowCommand(BorrowedListDto borrowPage): ICommand<NewBorrowPageResult>;

    public record NewBorrowPageResult(Guid Id);

    public class CreateNewBorrowCommandValidator : AbstractValidator<NewBorrowCommand>
    {
        public CreateNewBorrowCommandValidator()
        {
            RuleFor(x => x.borrowPage.items).NotEmpty().WithMessage("books for borrow is required");
        }
    }

    internal class NewBorrowPageHandler(BorrowDBContext dbContext)
        : ICommandHandler<NewBorrowCommand, NewBorrowPageResult>
    {
        public async Task<NewBorrowPageResult> Handle(NewBorrowCommand command, CancellationToken cancellationToken)
        {

           

            var newBorrow = NewBorrowList(command.borrowPage);

            dbContext.BorrowEntries.Add(newBorrow);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new NewBorrowPageResult(newBorrow.Id);
        }

        private BorrowList NewBorrowList(BorrowedListDto borrowPageDto)
        {
            var newBorrow = BorrowList.Create(Guid.NewGuid(),
                borrowPageDto.UserId);

            borrowPageDto.items.ForEach(item =>
            {
                newBorrow.BorrowBook(
                    item.BookId,
                    item.BorrowedEntryId,
                    item.Title);
            });
                return newBorrow;
        }
    }
}
