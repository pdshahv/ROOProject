using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrowing.LibBorrow.Dtos
{
    public record BorrowedListItemDto(
        Guid _id,
        Guid BorrowedEntryId,
        Guid BookId,
        string Title
        
        );

}
