using PortfolioApiV1.Models.Domain;

namespace PortfolioApiV1.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
    }
}
