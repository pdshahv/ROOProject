


using Shared.DDD;

namespace Borrowing.LibBorrow.Models
{
    public  class BorrowEntry :Aggregate<Guid>
    {

        private Guid _id;
        public Guid UserId { get; set; } = default;

        private readonly List<BorrowEntriesItem> _entries = new();

        public IReadOnlyList<BorrowEntriesItem> Entries => _entries.AsReadOnly();

        public static BorrowEntry Create(Guid id,Guid _userid)
        {
            var borrowEntry = new BorrowEntry
            {
              
                UserId = _userid

            };
            return borrowEntry;
        }

        public void BorrowBook(Guid BorrowEntryId, Guid bookId, string bookName)
        {

            var newItem = new BorrowEntriesItem(BorrowEntryId, bookId, bookName);
            _entries.Add(newItem);
        }

        public void ReturnBook(Guid _bookId)
        {
            var existingItem = Entries.FirstOrDefault(x => x.BookId == _bookId);
            if (existingItem != null)
            {
                _entries.Remove(existingItem);
            }
        }
    }
}
