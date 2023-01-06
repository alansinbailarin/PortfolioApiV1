namespace PortfolioApiV1.Models.Domain
{
    public class Trajectory
    {
        public Guid TrajectoryId { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Visibility { get; set; }
        public string? Link { get; set; }
        public DateTime CreatedAt { get; set; }

        public User? User { get; set; }
        public Guid? UserId { get; set; }
    }
}
