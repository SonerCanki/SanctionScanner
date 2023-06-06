using SanctionScanner.Common.DTOs.Base;

namespace SanctionScanner.Common.DTOs.Book
{
    public class BorrowBookRequest : BaseDto
    {
        public string? Borrower { get; set; }
        public DateTime? ReturnTime { get; set; }
    }
}
