


using Shared.DDD;

namespace Borrowing.LibBorrow.Models
{
    public  class BorrowList :Aggregate<Guid>
    {

        private Guid _id;
        public Guid UserId { get; set; } = default;

        private readonly List<BorrowListItem> _entries = new();

        public IReadOnlyList<BorrowListItem> Items => _entries.AsReadOnly();

        public static BorrowList Create(Guid id,Guid _userid)
        {
            var borrowEntry = new BorrowList
            {
              
                UserId = _userid

            };
            return borrowEntry;
        }

        public void BorrowBook(Guid BorrowEntryId, Guid bookId, string bookName)
        {

            var newItem = new BorrowListItem(BorrowEntryId, bookId, bookName);
            _entries.Add(newItem);
        }

        public void ReturnBook(Guid _bookId)
        {
            var existingItem = Items.FirstOrDefault(x => x.BookId == _bookId);
            if (existingItem != null)
            {
                _entries.Remove(existingItem);
            }
        }
    }
}
