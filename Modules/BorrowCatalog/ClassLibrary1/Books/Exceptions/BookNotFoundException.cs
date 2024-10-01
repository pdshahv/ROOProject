using Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Books.Exceptions
{
    public class BookNotFoundException : NotFoundException
    {

        public BookNotFoundException(string bookname) 
            : base("Book Title", bookname
                  
                  )
        {
        }
    }
}
