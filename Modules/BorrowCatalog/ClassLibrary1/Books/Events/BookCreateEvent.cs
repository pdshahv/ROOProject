


namespace BookManagement.Books.Events
{
    public record class BookAddEvent(Book Book) : IDomainEvent;
   
}
