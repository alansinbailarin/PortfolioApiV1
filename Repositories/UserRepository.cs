using Microsoft.EntityFrameworkCore;
using PortfolioApiV1.Data;
using PortfolioApiV1.Models.Domain;

namespace PortfolioApiV1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PortfolioDbContext portfolioDbContext;

        public UserRepository(PortfolioDbContext portfolioDbContext)
        {
            this.portfolioDbContext = portfolioDbContext;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await portfolioDbContext.Users
                .Include(x => x.Posts)
                .Include(x => x.Educations)
                .Include(x => x.Languages)
                .Include(x => x.Location)
                .Include(x => x.Ocupations)
                .Include(x => x.Socials)
                .Include(x => x.SoftSkills)
                .Include(x => x.TechnicalSkills)
                .Include(x => x.Trajectories)
                .Include(x => x.WorkRecords)
                .ToListAsync();
        }
    }
}
