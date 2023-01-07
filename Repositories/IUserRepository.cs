using PortfolioApiV1.Models.Domain;

namespace PortfolioApiV1.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(Guid UserId);
        Task<User> AddUserAsync(User User);
        Task<User> UpdateUserAsync(Guid UserId, User User);
        Task<User> DeleteUserAsync(Guid UserId);
        Task<User> GetByFullName(string FullName);
    }
}
