
using BooksCatalog.Books.Dtos;
using BooksCatalog.Data;
using FluentValidation;

namespace BooksCatalog.Books.Features.CreateBook
{

    public record CreateBookCommand(BookDto Book)
        :ICommand<CreateBookResult>;

    public record CreateBookResult(Guid Id);

    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Book.Name).NotEmpty().WithMessage("Name is required");
        }
    }
    internal class CreateBookHandler(BooksCatalogDBContext dBContext)
        :ICommandHandler<CreateBookCommand,CreateBookResult>
    {
        public async Task<CreateBookResult> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = CreateNewBook(command.Book);
        
             dBContext.Books.Add(book);

            await dBContext.SaveChangesAsync(cancellationToken);

            return new CreateBookResult(book.Id);
        }

        private Book CreateNewBook(BookDto bookDto)
        {
            var book = Book.Create(
                Guid.NewGuid(),
                bookDto.Name,
                bookDto.Description);
       
            return book;
        }
    }
}
