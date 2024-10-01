using BookManagement.Books.Events;
using Shared.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Books.Models
{
    public class Book : Aggregate<Guid>
    {

        public string Name { get; set; } = default!;
        public string Description { get; set; }


        public static Book Create(Guid _Id, string _name, string _description)
        {
            Book book = new Book()
            {
                Id = _Id,
                Name = _name,
                Description = _description
            };

            //book.AddDomainEvent(new BookCreatedEvent(book));

            return book;
        }



        public static Book Borrow(Guid _Id, string _name, string _description)
        {
            Book book = new Book()
            {
                Id = _Id,
                Name = _name
            };

            book.AddDomainEvent(new BookBorrowEvent(book));
            return book;
        }

        public void Update(string _name, string _description)
        {
            Name = _name;
            Description = _description;
        }
    }
}
