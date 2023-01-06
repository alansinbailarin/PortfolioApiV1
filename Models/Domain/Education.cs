namespace PortfolioApiV1.Models.Domain
{
    public class Education
    {
        public Guid EducationId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsEnded { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<User>? Users { get; set; }
    }
}
