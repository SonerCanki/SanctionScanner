using SanctionScanner.Common.DTOs.Base;

namespace SanctionScanner.Common.DTOs.Book
{
    public class BookResponse : BaseDto
    {
        public string Name { get; set; }
        public string Writer { get; set; }
        public bool IsInLibrary { get; set; }
        public string Url { get; set; }
        public string? Borrower { get; set; }
        public DateTime? BorrawingTime { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
