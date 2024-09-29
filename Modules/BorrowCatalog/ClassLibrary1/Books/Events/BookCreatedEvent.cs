


namespace BookManagement.Books.Events
{
    public record class BookCreatedEvent(Book Book) : IDomainEvent;
   
}
