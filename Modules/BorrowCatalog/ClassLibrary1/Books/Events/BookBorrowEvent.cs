


namespace BookManagement.Books.Events
{
    public record class BookBorrowEvent(Book Book) : IDomainEvent;
   
}
