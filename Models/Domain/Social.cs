namespace PortfolioApiV1.Models.Domain
{
    public class Social
    {
        public Guid SocialId { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }

        public IEnumerable<User>? Users { get; set; }
    }
}
