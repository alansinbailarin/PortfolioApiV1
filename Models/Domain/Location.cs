namespace PortfolioApiV1.Models.Domain
{
    public class Location
    {
        public Guid LocationId { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? StillHere { get; set; }
        public DateTime CreatedAt { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
