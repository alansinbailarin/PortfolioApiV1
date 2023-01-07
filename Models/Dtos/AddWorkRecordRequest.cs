namespace PortfolioApiV1.Models.Dtos
{
    public class AddWorkRecordRequest
    {
        public string Title { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsEnded { get; set; }
        public Guid? UserId { get; set; }
    }
}
