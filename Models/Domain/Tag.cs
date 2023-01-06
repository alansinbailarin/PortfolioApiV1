namespace PortfolioApiV1.Models.Domain
{
    public class Tag
    {
        public Guid TagId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
