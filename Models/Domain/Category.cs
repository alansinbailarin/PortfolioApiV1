namespace PortfolioApiV1.Models.Domain
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<Post>? Posts { get; set; }
    }
}
