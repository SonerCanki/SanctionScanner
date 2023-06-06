namespace SanctionScanner.Common.DTOs.Base
{
    public class BaseDto
    {
        public Guid Id { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
