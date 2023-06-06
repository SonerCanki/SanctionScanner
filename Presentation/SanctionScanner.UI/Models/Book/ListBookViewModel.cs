namespace SanctionScanner.UI.Models.Book
{
    public class ListBookViewModel
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string Writer { get; set; }
        public bool IsInLibrary { get; set; }
        public string Url { get; set; }
        public string? Borrower { get; set; }
        public DateTime BorrawingTime { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}
