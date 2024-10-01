using Shared.DDD;

namespace Borrowing.LibBorrow.Models
{
    public class BorrowEntriesItem :Entity<Guid>
    {
        private Guid _id;
        public Guid BorrowEntryId { get; private set; } = default!;
        public Guid BookId { get; set; } = default;

        public string Title { get; set; } = default;

        public BorrowEntriesItem()
        { }
            public BorrowEntriesItem(Guid _BorrowEntryId, Guid _bookId, string _title)
        {
            BorrowEntryId= _BorrowEntryId;
            BookId = _bookId;
                Title = _title;
        }
    }
}
