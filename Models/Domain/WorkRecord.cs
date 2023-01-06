namespace PortfolioApiV1.Models.Domain
{
    public class WorkRecord
    {
        public Guid WorkRecordId { get; set; }
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsEnded { get; set; }
        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }
        public Guid? UserId { get; set; }
    }
}
