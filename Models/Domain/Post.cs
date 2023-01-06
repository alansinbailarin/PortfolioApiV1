namespace PortfolioApiV1.Models.Domain
{
    public class Post
    {
        public Guid PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string? Body { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
