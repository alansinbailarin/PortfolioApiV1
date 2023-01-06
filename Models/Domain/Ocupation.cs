namespace PortfolioApiV1.Models.Domain
{
    public class Ocupation
    {
        public Guid OcupationId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsActive { get; set; }

        public IEnumerable<User>? Users { get; set; }
    }
}
