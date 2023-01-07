namespace PortfolioApiV1.Models.Dtos
{
    public class AddTrajectoryRequest
    {
        public string Title { get; set; }
        public string? Body { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Visibility { get; set; }
        public string? Link { get; set; }
        public Guid? UserId { get; set; }
    }
}
