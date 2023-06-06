using SanctionScanner.Common.DTOs.Base;

namespace SanctionScanner.Common.DTOs.Book
{
    public class AddBookRequest : BaseDto
    {
        public string Name { get; set; }
        public string Writer { get; set; }
        public string Url { get; set; }
    }
}
