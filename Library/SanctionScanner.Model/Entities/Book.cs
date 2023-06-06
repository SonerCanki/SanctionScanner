using SanctionScanner.Core.Entity;

namespace SanctionScanner.Model.Entities
{
    public class Book : CoreEntity
    {

        public string Name { get; set; }
        public string Writer { get; set; }
        public bool IsInLibrary { get; set; }
        public string Url { get; set; }
        public string? Borrower { get; set; }
        public DateTime? BorrawingTime{ get; set; }
        public DateTime? ReturnTime{ get; set; }
    }
}
