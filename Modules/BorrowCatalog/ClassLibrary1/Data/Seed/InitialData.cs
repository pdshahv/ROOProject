using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Data.Seed
{
    public static class InitialData
    {
        public static IEnumerable<Book> Books =>
        new List<Book>
        { Book.Create(Guid.NewGuid(),"Mahabharata", "Fiction")};
    }
}
