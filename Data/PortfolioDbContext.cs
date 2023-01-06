using Microsoft.EntityFrameworkCore;
using PortfolioApiV1.Models.Domain;

namespace PortfolioApiV1.Data
{
    public class PortfolioDbContext: DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options): base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Ocupation> Ocupations { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<SoftSkills> SoftSkills { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TechnicalSkills> TechnicalSkills { get; set; }
        public DbSet<Trajectory> Trajectories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkRecord> WorkRecords { get; set; }

    }
}
