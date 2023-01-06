namespace PortfolioApiV1.Models.Domain
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? PostId { get; set; }
        public Guid? UserId { get; set; }

        public Post? Post { get; set; }
        public User? User { get; set; }
    }
}
