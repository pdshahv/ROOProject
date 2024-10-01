using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrowing.LibBorrow.Dtos
{
    public record BorrowedListDto(
        Guid _id,
        Guid UserId,
        List<BorrowedListItemDto> items);

}
