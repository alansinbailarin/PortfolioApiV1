
namespace PortfolioApiV1.Models.Domain
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? Avatar { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }        
        public string Salt { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public bool IsAdmin { get; set; }
        public string? About { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<Post>? Posts { get; set; }
        public IEnumerable<Education>? Educations { get; set; }
        public IEnumerable<Language>? Languages { get; set; }
        public Location? Location { get; set; }
        public IEnumerable<Ocupation>? Ocupations { get; set; }
        public IEnumerable<Social>? Socials { get; set; }
        public IEnumerable<SoftSkills>? SoftSkills { get; set; }
        public IEnumerable<TechnicalSkills>? TechnicalSkills { get; set; }
        public IEnumerable<Trajectory>? Trajectories { get; set; }
        public IEnumerable<WorkRecord>? WorkRecords { get; set; }
        public IEnumerable<Comment>? Comments { get; set; }
    }
}
