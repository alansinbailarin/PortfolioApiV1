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

        public async Task<User> AddUserAsync(User User)
        {
            User.UserId = Guid.NewGuid();
            User.CreatedAt = DateTime.Now;

            await portfolioDbContext.AddAsync(User);
            await portfolioDbContext.SaveChangesAsync();

            return User;
        }

        public async Task<User> DeleteUserAsync(Guid UserId)
        {
            var existingUser = await portfolioDbContext.Users.FindAsync(UserId);

            if(existingUser == null)
            {
                return null;
            }

            portfolioDbContext.Users.Remove(existingUser);
            await portfolioDbContext.SaveChangesAsync();

            return existingUser;
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

        public async Task<User> GetByIdAsync(Guid UserId)
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
                .FirstOrDefaultAsync(x => x.UserId == UserId);
        }

        public async Task<User> UpdateUserAsync(Guid UserId, User User)
        {
            var existingUser = await portfolioDbContext.Users.FindAsync(UserId);

            if (existingUser != null)
            {
                existingUser.Avatar = User.Avatar;
                existingUser.Name = User.Name;
                existingUser.LastName = User.LastName;
                existingUser.Salt = User.Salt;
                existingUser.Email = User.Email;
                existingUser.Password = User.Password;
                existingUser.Phone = User.Phone;
                existingUser.Birthday = User.Birthday;
                existingUser.IsAdmin = User.IsAdmin;
                existingUser.About = User.About;

                await portfolioDbContext.SaveChangesAsync();

                return existingUser;
            }

            return null;
        }
    }
}
